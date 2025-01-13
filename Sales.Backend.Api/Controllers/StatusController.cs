using Microsoft.AspNetCore.Mvc;


namespace Stackup.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly ILogger<StatusController> _logger;   

    public StatusController(ILogger<StatusController> logger)
    {
        _logger = logger;   
    }

    [HttpGet()]
    public ActionResult<string> Get()
    {
       _logger.LogInformation("API Status Get Called");
       return "Api running successfully..";
    }
}
