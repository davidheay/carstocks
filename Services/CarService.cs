using carstocks.Repository;
using carstocks.models;
using carstocks.Exceptions;

namespace carstocks.services;
public class CarService : ICarService
{

    private readonly ICarRepository _iCarRepository;
    private readonly ILogger<CarService> _logger;

    public CarService(ICarRepository iCarRepository, ILogger<CarService> logger)
    {
        _iCarRepository = iCarRepository;
        _logger = logger;
    }

    public Car AddCar(Car car)
    {
        try
        {
            List<Dealer> dealers = _iCarRepository.GetDealers();
            if (!dealers.Any(dealer => dealer.Id == car.DealerId))
            {
                throw new NotFoundException("Invalid dealer id");
            }
            return _iCarRepository.AddCar(car);
        }
        catch (Exception e)
        {
            _logger.LogError("Error in CarService::AddCar  input({input}) error: {message}", car, e.Message);
            throw;
        }
    }

    public void DeleteCar(int dealerId, int carId)
    {
        try
        {
            Car? toDelete = _iCarRepository.GetCarById(dealerId, carId);
            if (toDelete == null)
            {
                throw new NotFoundException("Car not found");
            }
            _iCarRepository.DeleteCar(carId);
        }
        catch (Exception e)
        {
            _logger.LogError("Error in CarService::DeleteCar input({input}) error: {message}", carId, e.Message);
            throw;
        }
    }
    public Car UpdateCar(Car updatedCar)
    {
        try
        {
            if (_iCarRepository.GetCarById(updatedCar.DealerId, updatedCar.Id) == null)
            {
                throw new NotFoundException("Not found car with id=" + updatedCar.Id);
            }
            return _iCarRepository.UpdateCar(updatedCar);
        }
        catch (Exception e)
        {
            _logger.LogError("Error in CarService::UpdateCar input({input}) error: {message}", updatedCar, e.Message);
            throw;
        }
    }

    public List<Car> GetCarsByDealerId(int dealerId)
    {
        try
        {
            List<Car> result = _iCarRepository.GetCarsByDealerId(dealerId);
            if (result == null || result.Count == 0)
            {
                throw new NotFoundException("No cars found for the given dealer ID");
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("Error in CarService::GetCarsByDealerId input({input1}) error: {message}", dealerId, e.Message);
            throw;
        }


    }


    public List<Car> SearchByBrandModel(int dealerId, string brand, string model)
    {
        try
        {
            List<Car> result = _iCarRepository.SearchByBrandModel(dealerId, brand, model);
            if (result == null || result.Count == 0)
            {
                throw new NotFoundException("No cars found for the given information");
            }
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("Error in CarService::SearchByBrandModel input({input1},{input2},{input3}) error: {message}", dealerId, brand, model, e.Message);
            throw;
        }
    }


}