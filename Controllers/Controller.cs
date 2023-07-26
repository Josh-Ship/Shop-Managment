using Microsoft.AspNetCore.Mvc;

namespace Shop_Sales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShopSale : ControllerBase
{
    private Shop_Sales.Services.RevenueTypeServices _revenueTypeService;
    private Shop_Sales.Database.Database _database;

    public ShopSale(Shop_Sales.Services.RevenueTypeServices revenueTypeServices)
    {
        _revenueTypeService = revenueTypeServices;
        _database = new Database.Database();
    }

    [HttpPost("Submit")]
    public IActionResult submit([FromBody] Shop_Sales.Models.RevenueType revenueType)
    {
        _revenueTypeService.addRevenue(revenueType);
        return Ok();
    }

    [HttpGet("DeleteAll")]
    public IActionResult DeleteAll()
    {
        
        return Ok();
    }
}
