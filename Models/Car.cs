using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace carstocks.models;

public class Car
{
    public int Id { get; set; }

    [Required]
    public string Brand { get; set; }

    [Required]
    public string Model { get; set; }

    public int Year { get; set; }
    public int Stock { get; set; }

    [JsonIgnore]
    public int DealerId { get; set; }

    [JsonConstructor]

    public Car(string brand, string model, int year, int stock)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Stock = stock;
    }
    public Car(int id, string brand, string model, int year, int dealerId, int stock)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Year = year;
        DealerId = dealerId;
        Stock = stock;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Stock: {Stock}, DealerId: {DealerId}";
    }

}
