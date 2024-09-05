using Microsoft.AspNetCore.Mvc;
using OnTheBeach.Domain.Requests;

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

    [HttpPost]
    public async Task<IActionResult> Search(HolidaySearchRequest request)
    {
        return Ok();
    }
}
