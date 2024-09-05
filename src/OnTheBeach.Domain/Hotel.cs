using System.Text.Json.Serialization;

namespace OnTheBeach.Domain;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonPropertyName("arrival_date")]
    public string ArrivalDate { get; set; }

    [JsonPropertyName("price_per_night")]
    public int PricePerNight { get; set; }

    [JsonPropertyName("local_airports")]
    public string[] LocalAirports { get; set; }

    public int Nights { get; set; }
}
