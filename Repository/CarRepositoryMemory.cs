using carstocks.models;
using carstocks.Exceptions;

namespace carstocks.Repository;


public class CarRepositoryMemory : ICarRepository
{

    private List<Car> Cars;
    private List<Dealer> Dealers;
    public CarRepositoryMemory()
    {
        Dealers = new List<Dealer>();
        Cars = new List<Car>();

        Dealers.Add(new Dealer(1238979213, "Elite Motors"));
        Cars.Add(new Car(1, "Toyota", "Camry", 2020, 1238979213, 5));
        Cars.Add(new Car(2, "Toyota", "Corolla", 2013, 1238979213, 2));
        Cars.Add(new Car(3, "Toyota", "RAV4", 2021, 1238979213, 4));
        Cars.Add(new Car(4, "BMW", "3 Series", 2022, 1238979213, 1));

        Dealers.Add(new Dealer(24424314, "Prestige Auto Group"));
        Cars.Add(new Car(5, "Honda", "Civic", 2003, 24424314, 0));
        Cars.Add(new Car(6, "Honda", "Accord", 2011, 24424314, 3));
        Cars.Add(new Car(7, "Honda", "CR-V", 2000, 24424314, 2));
        Cars.Add(new Car(8, "BMW", "5 Series", 2006, 24424314, 1));

        Dealers.Add(new Dealer(3213152, "Superior Cars Inc."));
        Cars.Add(new Car(9, "Ford", "Mustang", 2003, 3213152, 1));
        Cars.Add(new Car(10, "Ford", "F-150", 2006, 3213152, 1));
        Cars.Add(new Car(11, "Ford", "Escape", 1982, 3213152, 2));
        Cars.Add(new Car(12, "BMW", "X3", 2023, 3213152, 3));
    }
    public List<Dealer> GetDealers()
    {
        return Dealers;
    }
    public Car AddCar(Car car)
    {
        car.Id = Cars.Count + 1;
        Cars.Add(car);
        return car;

    }

    public void DeleteCar(int carId)
    {
        Cars.RemoveAll(car => car.Id == carId);
    }

    public Car UpdateCar(Car updatedCar)
    {
        Car carToUpdate = Cars.First(car => car?.Id == updatedCar.Id);

        carToUpdate.Brand = updatedCar.Brand;
        carToUpdate.Model = updatedCar.Model;
        carToUpdate.Year = updatedCar.Year;
        carToUpdate.Stock = updatedCar.Stock;
        return carToUpdate;

    }


    public Car? GetCarById(int dealerId, int carId)
    {
        Car? car = Cars.FirstOrDefault(car => car.Id.Equals(carId) && car.DealerId.Equals(dealerId));
        return car;
    }


    public List<Car> SearchByBrandModel(int dealerId, string brand, string model)
    {
        return Cars.Where(car => car.DealerId.Equals(dealerId) &&
         car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
         car.Model.Equals(model, StringComparison.OrdinalIgnoreCase)).ToList();

    }
    public List<Car> GetCarsByDealerId(int dealerId)
    {
        return Cars.Where(car => car.DealerId.Equals(dealerId)).ToList();
    }

}


