using Microsoft.AspNetCore.Mvc;

namespace Shop_Manager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopSales : ControllerBase
{
    private Shop_Manager.Services.RevenueTypeServices _revenueTypeService;
    private Shop_Manager.Database.Database _database;

    public ShopSales(Shop_Manager.Services.RevenueTypeServices revenueTypeServices)
    {
        _revenueTypeService = revenueTypeServices;
        _database = new Database.Database();
    }

    [HttpPost("Submit")]
    public IActionResult submit([FromBody] Shop_Manager.Models.RevenueType revenueType)
    {
        _revenueTypeService.addRevenue(revenueType);
        return Ok();
    }

    [HttpGet("GetRevenueById")]
    public IActionResult getRevenue(int id)
    {
        var found = _revenueTypeService.getRevenue(id);
        string objectString = found == null ? "Object is null" : found.ToString();
        return Ok(objectString);
    }

    [HttpGet("DeleteAll")]
    public IActionResult DeleteAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("Testing")]
    public IActionResult testing()
    {
        return Ok("This is a Test!");
    }
}
