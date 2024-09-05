using System.ComponentModel;

namespace OnTheBeach.Domain.Requests;

public class HolidaySearchRequest
{
    [DefaultValue("MAN")]
    public string DepartingFrom { get; set; }

    [DefaultValue("TFS")]
    public string TravellingTo { get; set; }

    //TODO change and handle to DateTime
    [DefaultValue("2023/07/01")]
    public string DepartureDate { get; set; }
}
