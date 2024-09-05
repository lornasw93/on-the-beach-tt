using Moq;
using OnTheBeach.Domain;
using OnTheBeach.Domain.Requests;
using OnTheBeach.Domain.Responses;

namespace OnTheBeach.Core.Tests;

public class HolidaySearchServiceTests
{
    private readonly Mock<IHolidaySearchService> _holidaySearchServiceMock;

    public HolidaySearchServiceTests()
    {
        _holidaySearchServiceMock = new Mock<IHolidaySearchService>();
    }

    [Fact]
    public void Search_ValidRequest_ReturnsFilteredFlightsAndHotels()
    {
        // Arrange
        var request = new HolidaySearchRequest
        {
            DepartingFrom = "MAN",
            TravellingTo = "PMI"
        };

        var expectedFlights = new List<Flight>
        {
            new Flight { Id = 3, Airline = "Trans American Airlines", From = "MAN", To = "PMI", Price = 170, DepartureDate = "2023-06-15" },
            new Flight { Id = 5, Airline = "Fresh Airways", From = "MAN", To = "PMI", Price = 130, DepartureDate = "2023-06-15" }
        };

        var expectedHotels = new List<Hotel>
        {
            new Hotel { Id = 3, Name = "Sol Katmandu Park & Resort", ArrivalDate = "2023-06-15", PricePerNight = 59, LocalAirports =[ "PMI" ], Nights = 14 },
            new Hotel { Id = 4, Name = "Sol Katmandu Park & Resort", ArrivalDate = "2023-06-15", PricePerNight = 59, LocalAirports = [ "PMI" ], Nights = 14 },
            new Hotel { Id = 5, Name = "Sol Katmandu Park & Resort", ArrivalDate = "2023-06-15", PricePerNight = 60, LocalAirports = [ "PMI" ], Nights = 10 },
            new Hotel { Id = 13, Name = "Jumeirah Port Soller", ArrivalDate = "2023-06-15", PricePerNight = 295, LocalAirports = [ "PMI" ], Nights = 10 }
        };

        _holidaySearchServiceMock.Setup(service => service.Search(request)).Returns(new HolidaySearchResponse
        {
            Flights = expectedFlights,
            Hotels = expectedHotels
        });

        // Act
        var response = _holidaySearchServiceMock.Object.Search(request);

        // Assert
        Assert.NotNull(response);
        Assert.Equal(expectedFlights.Count, response.Flights.Count());
        Assert.Equal(expectedHotels.Count, response.Hotels.Count());
        Assert.All(response.Flights, flight => Assert.Equal("MAN", flight.From));
        Assert.All(response.Hotels, hotel => Assert.Contains("PMI", hotel.LocalAirports));
    }

    [Fact]
    public void Search_NoMatchingResults_ReturnsEmptyLists()
    {
        // Arrange
        var request = new HolidaySearchRequest
        {
            DepartingFrom = "XYZ",
            TravellingTo = "ABC"
        };

        _holidaySearchServiceMock.Setup(service => service.Search(request)).Returns(new HolidaySearchResponse
        {
            Flights = new List<Flight>(),
            Hotels = new List<Hotel>()
        });

        // Act
        var response = _holidaySearchServiceMock.Object.Search(request);

        // Assert
        Assert.NotNull(response);
        Assert.Empty(response.Flights);
        Assert.Empty(response.Hotels);
    }

    //[Fact]
    //public void Search_InvalidJsonData_ReturnsEmptyResponse()
    //{
    //    // Arrange
    //    var invalidJsonDataService = new Mock<HolidaySearchService>();
    //    invalidJsonDataService.Setup(service => service.Search(It.IsAny<HolidaySearchRequest>()))
    //                          .Throws(new System.Text.Json.JsonException());

    //    var request = new HolidaySearchRequest
    //    {
    //        DepartingFrom = "MAN",
    //        TravellingTo = "PMI"
    //    };

    //    // Act and Assert
    //    var exception = Record.Exception(() => invalidJsonDataService.Object.Search(request));
    //    Assert.IsType<System.Text.Json.JsonException>(exception);
    //}

    //[Fact]
    //public void Search_NullOrEmptyRequest_ReturnsEmptyResponse()
    //{
    //    // Arrange
    //    HolidaySearchRequest request = null;

    //    _holidaySearchServiceMock.Setup(service => service.Search(request)).Returns(new HolidaySearchResponse());

    //    // Act
    //    var response = _holidaySearchServiceMock.Object.Search(request);

    //    // Assert
    //    Assert.NotNull(response);
    //    Assert.Empty(response.Flights);
    //    Assert.Empty(response.Hotels);
    //}
}
