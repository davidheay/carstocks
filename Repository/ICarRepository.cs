
using carstocks.models;

namespace carstocks.Repository;

public interface ICarRepository
{


    public List<Dealer> GetDealers();
    public Car AddCar(Car car);
    public void DeleteCar(int carId);
    public Car UpdateCar(Car updatedCar);
    public Car? GetCarById(int dealerId, int carId);
    public List<Car> SearchByBrandModel(int dealerId, string brand, string model);
    public List<Car> GetCarsByDealerId(int dealerId);
}