using OnTheBeach.Domain.Requests;
using OnTheBeach.Domain.Responses;

namespace OnTheBeach.Core;

public interface IHolidaySearchService
{
    HolidaySearchResponse Search(HolidaySearchRequest request);
}
