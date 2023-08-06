namespace Shop_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class EmployeeShiftController : ControllerBase
{
    private Services.EmployeeShiftServices _employeeShiftServices;

    public EmployeeShiftController(Services.EmployeeShiftServices employeeShiftServices)
    {
        _employeeShiftServices = employeeShiftServices;
    }

    [HttpPost("Add")]
    public IActionResult addEmployeeShift([FromBody]Models.EmployeeShift record)
    {
       return Ok("Added:\n" + _employeeShiftServices.add(record).ToString() + " to database.");
    }
    
    [HttpGet("Find")]
    public IActionResult findEmployeeShift()
    {
        return Ok("Find results:\n" + _employeeShiftServices.find());
    }

    [HttpGet("Find/id")]
    public IActionResult findEmployeeShift(int id)
    {
        return Ok("Find results:\n" + _employeeShiftServices.find(id));
    }

    [HttpGet("Find/date")]
    public IActionResult findEmployeeShift(string date)
    {
        return Ok("Find results:\n" + _employeeShiftServices.find(date));
    }

    [HttpGet("Find/name")]
    public IActionResult findEmployeeShiftByName(string name)
    {
        return Ok("Find results:\n" + _employeeShiftServices.findByName(name));
    }

    [HttpGet("Find/date&name")]
    public IActionResult findEmployeeShiftByDateAndName(string date, string name)
    {
        return Ok("Find results:\n" + _employeeShiftServices.findByDateAndName(date,name));
    }
    
}
