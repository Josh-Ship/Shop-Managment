namespace Shop_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class DriverTripController : ControllerBase
{
    private Services.DriverTripServices _driverTripServices;

    public DriverTripController(Services.DriverTripServices driverTripServices)
    {
        _driverTripServices = driverTripServices;
    }

    [HttpPost("Add")]
    public IActionResult addDriverTrip([FromBody]Models.DriverTrip driverTrip)
    {
       return Ok("Added:\n" + _driverTripServices.add(driverTrip).ToString() + " to database.");
    }
    
    [HttpGet("Find")]
    public IActionResult findDriverTrip()
    {
        return Ok("Find results:\n" + _driverTripServices.find());
    }

    [HttpGet("Find/id")]
    public IActionResult findDriverTrip(int id)
    {
        return Ok("Find results:\n" + _driverTripServices.find(id));
    }

    [HttpGet("Find/name")]
    public IActionResult findDriverTripByName(string name)
    {
        return Ok("Find results:\n" + _driverTripServices.find(name));
    }

    [HttpGet("Find/date&name")]
    public IActionResult findDriverTripByDateAndName(string name)
    {
        return Ok("Find results:\n" + _driverTripServices.find(name));
    }


}