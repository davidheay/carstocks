using carstocks.models;
using carstocks.services;
using Microsoft.AspNetCore.Mvc;

namespace carstocks.Controllers;

[ApiController]
[Route("api/{dealerId}/cars")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarService _iCarService;

    public CarController(ILogger<CarController> logger, ICarService iCarService)
    {
        _logger = logger;
        _iCarService = iCarService;
    }

    [HttpGet(Name = "GetCars")]
    [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public IActionResult GetCarsByDealerId(int dealerId)
    {
        try
        {
            return Ok(_iCarService.GetCarsByDealerId(dealerId));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost(Name = "AddCar")]
    [ProducesResponseType(typeof(Car), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
    public IActionResult AddCar(int dealerId, [FromBody] Car car)
    {
        try
        {
            car.DealerId = dealerId;
            Car created = _iCarService.AddCar(car);
            return Created($"/api/cars/{created.Id}", created);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{carId}", Name = "DeleteCar")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
    public IActionResult DeleteCar(int dealerId, int carId)
    {
        try
        {
            _iCarService.DeleteCar(dealerId, carId);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{carId}", Name = "UpdateCar")]
    [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
    public IActionResult UpdateStock(int dealerId, int carId, [FromBody] Car car)
    {
        try
        {
            car.DealerId = dealerId;
            car.Id = carId;
            Car updatedCar = _iCarService.UpdateCar(car);
            return Ok(updatedCar);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("search",Name = "SearchByBrandModel")]
    [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public IActionResult SearchByBrandModel(int dealerId, string brand, string model)
    {
        try
        {
            return Ok(_iCarService.SearchByBrandModel(dealerId, brand, model));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
