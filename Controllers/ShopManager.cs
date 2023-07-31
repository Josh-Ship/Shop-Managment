using Microsoft.AspNetCore.Mvc;

namespace Shop_Manager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopController : ControllerBase
{
    private Shop_Manager.Database.Database _database;
    private Shop_Manager.Services.RecordsServices _recordServices;

    public ShopController(Shop_Manager.Services.RecordsServices recordServices)
    {
        _recordServices = recordServices;
        _database = new Database.Database();
    }

    [HttpPost("Submit")]
    public IActionResult submit([FromBody]Shop_Manager.Models.Records record)
    {
       return Ok("Added:\n" + _recordServices.add(record).ToString() + " to database.");
    }
    
    [HttpGet("Find")]
    public IActionResult findRevenue()
    {
        return Ok("Find results:\n" + _recordServices.find());
    }

    [HttpGet("Find/id")]
    public IActionResult findRevenue(int id)
    {
        return Ok("Find results:\n" + _recordServices.find(id));
    }

    [HttpGet("Find/date")]
    public IActionResult findRevenue(string date)
    {
        return Ok("Find results:\n" + _recordServices.find(date));
    }
}
