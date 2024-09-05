using OnTheBeach.Domain.Requests;
using OnTheBeach.Domain;

namespace OnTheBeach.Core;

public interface IHolidaySearchService
{
    IEnumerable<Holiday> Search(HolidaySearchRequest request);
}
