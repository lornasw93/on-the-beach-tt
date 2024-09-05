using Microsoft.AspNetCore.Mvc;
using OnTheBeach.Core;
using OnTheBeach.Domain.Requests;

namespace OnTheBeach.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HolidaySearchController : ControllerBase
{
    private readonly ILogger<HolidaySearchController> _logger;
    private readonly IHolidaySearchService _holidaySearchService;

    public HolidaySearchController(ILogger<HolidaySearchController> logger, IHolidaySearchService holidaySearchService)
    {
        _logger = logger;
        _holidaySearchService = holidaySearchService;
    }

    [HttpPost]
    public async Task<IActionResult> Search(HolidaySearchRequest request)
    {
        var holidays = _holidaySearchService.Search(request);

        return Ok(holidays);
    }
}
