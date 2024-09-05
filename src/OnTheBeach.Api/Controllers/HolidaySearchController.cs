using Microsoft.AspNetCore.Mvc;

namespace OnTheBeach.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HolidaySearchController : ControllerBase
{
    private readonly ILogger<HolidaySearchController> _logger;

    public HolidaySearchController(ILogger<HolidaySearchController> logger)
    {
        _logger = logger;
    }
}
