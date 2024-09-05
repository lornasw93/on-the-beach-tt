using System.ComponentModel;

namespace OnTheBeach.Domain.Requests;

public class HolidaySearchRequest
{
    [DefaultValue("MAN")]
    public string DepartingFrom { get; set; }

    [DefaultValue("TFS")]
    public string TravellingTo { get; set; }

    //[DefaultValue("2023/07/01")]
    //public DateTime DepartureDate { get; set; }

    //[DefaultValue(null)]
    //public int Duration { get; set; }
}
