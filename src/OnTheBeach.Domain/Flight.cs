using System.Text.Json.Serialization;

namespace OnTheBeach.Domain;

public class Flight
{
    public int Id { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Price { get; set; }

    //TODO change and handle to DateTime
    [JsonPropertyName("departure_date")]
    public string DepartureDate { get; set; }
}
