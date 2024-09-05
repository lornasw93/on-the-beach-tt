namespace OnTheBeach.Domain.Responses;

public class HolidaySearchResponse
{
    public IEnumerable<Flight> Flights { get; set; }
    public IEnumerable<Hotel> Hotels { get; set; }
}
