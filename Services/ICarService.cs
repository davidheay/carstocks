using carstocks.models;

namespace carstocks.services;
public interface ICarService
{


    public Car AddCar(Car car);
    public void DeleteCar(int dealerId, int carId);
    public Car UpdateCar(Car updatedCar);
    public List<Car> GetCarsByDealerId(int dealerId);
    public List<Car> SearchByBrandModel(int dealerId, string brand, string model);

}