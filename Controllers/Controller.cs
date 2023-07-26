using Microsoft.AspNetCore.Mvc;

namespace Shop_Sales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;

    public Controller(ILogger<Controller> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public void Get()
    {
        Console.WriteLine("Hello");
    }
}
