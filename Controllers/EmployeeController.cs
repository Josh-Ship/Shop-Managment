namespace Shop_Manager.Controllers;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private Services.EmployeeServices _employeeServices;

    public EmployeeController(Services.EmployeeServices employeeServices)
    {
        _employeeServices = employeeServices;
    }

    [HttpPost("Add")]
    public IActionResult addEmployee([FromBody]Models.Employee employee)
    {
       return Ok("Added:\n" + _employeeServices.add(employee).ToString() + " to database.");
    }
    
    [HttpGet("Find/")]
    public IActionResult findEmployee()
    {
        return Ok("Find results:\n" + _employeeServices.find());
    }

    [HttpGet("Find/id")]
    public IActionResult findEmployee(int id)
    {
        return Ok("Find results:\n" + _employeeServices.find(id));
    }

    [HttpGet("Find/name")]
    public IActionResult findEmployeeByName(string name)
    {
        return Ok("Find results:\n" + _employeeServices.find(name));
    }
}