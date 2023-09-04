using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController: ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbContext;

    public HelloWorldController(IHelloWorldService helloWorld, TareasContext db)
    {
        helloWorldService = helloWorld;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();

        return Ok();
    }
}