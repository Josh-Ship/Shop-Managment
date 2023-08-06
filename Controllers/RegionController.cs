namespace Shop_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class RegionController : ControllerBase
{
    private Services.RegionServices _regionServices;

    public RegionController(Services.RegionServices regionServices)
    {
        _regionServices = regionServices;
    }


    [HttpPost("Add")]
    public IActionResult addRegion([FromBody]Models.Region region)
    {
       return Ok("Added:\n" + _regionServices.add(region).ToString() + " to database.");
    }
    
    [HttpGet("Find")]
    public IActionResult findRegion()
    {
        return Ok("Find results:\n" + _regionServices.find());
    }

    [HttpGet("Find/id")]
    public IActionResult findRegion(int id)
    {
        return Ok("Find results:\n" + _regionServices.find(id));
    }


    [HttpGet("Find/name")]
    public IActionResult findRegionByName(string name)
    {
        return Ok("Find results:\n" + _regionServices.find(name));
    }

}