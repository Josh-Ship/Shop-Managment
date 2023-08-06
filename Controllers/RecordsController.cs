namespace Shop_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class RecordsController : ControllerBase
{
    private Services.RecordServices _recordServices;

    public RecordsController(Services.RecordServices recordServices)
    {
        _recordServices = recordServices;
    }

    [HttpPost("Add")]
    public IActionResult addRecord([FromBody]Models.Records record)
    {
       return Ok("Added:\n" + _recordServices.add(record).ToString() + " to database.");
    }
    
    [HttpGet("Find")]
    public IActionResult findRecord()
    {
        return Ok("Find results:\n" + _recordServices.find());
    }

    [HttpGet("Find/id")]
    public IActionResult findRecord(int id)
    {
        return Ok("Find results:\n" + _recordServices.find(id));
    }

    [HttpGet("Find/date")]
    public IActionResult findRecord(string date)
    {
        return Ok("Find results:\n" + _recordServices.find(date));
    }

    [HttpGet("Find/name")]
    public IActionResult findRecordByName(string name)
    {
        return Ok("Find results:\n" + _recordServices.findByName(name));
    }

    [HttpGet("Find/date&name")]
    public IActionResult findRecordByDateAndName(string date, string name)
    {
        return Ok("Find results:\n" + _recordServices.find(date,name));
    }

    
}
