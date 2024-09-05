using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using OnTheBeach.Api.Controllers;
using OnTheBeach.Core;
using OnTheBeach.Domain;
using OnTheBeach.Domain.Requests;
using OnTheBeach.Domain.Requests.Validators;
using OnTheBeach.Domain.Responses;

namespace OnTheBeach.Api.Tests;

public class HolidaySearchControllerTests
{
    private readonly Mock<ILogger<HolidaySearchController>> _loggerMock;
    private readonly Mock<IHolidaySearchService> _holidaySearchServiceMock;
    private readonly HolidaySearchController _controller;

    public HolidaySearchControllerTests()
    {
        _loggerMock = new Mock<ILogger<HolidaySearchController>>();
        _holidaySearchServiceMock = new Mock<IHolidaySearchService>();
        _controller = new HolidaySearchController(_loggerMock.Object, _holidaySearchServiceMock.Object);
    }

    [Fact]
    public async Task Search_InvalidRequest_ReturnsBadRequest()
    {
        // Arrange
        var invalidRequest = new HolidaySearchRequest() { DepartingFrom = "", TravellingTo = "" };

        var validator = new HolidaySearchRequestValidator();
        var validationResult = validator.Validate(invalidRequest);

        // Act
        var result = await _controller.Search(invalidRequest);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        var badRequestResult = result as BadRequestObjectResult;

        //TODO fix and finish tests
        Assert.Contains(validationResult.Errors, e => e.ErrorMessage == "'Departing From' must not be empty.");
        Assert.Contains(validationResult.Errors, e => e.ErrorMessage == "'Travelling To' must not be empty.");

        //Assert.Equal(validationResult.Errors, badRequestResult.Value);
        //_loggerMock.Verify(logger => logger.LogError(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
    }

    [Fact]
    public async Task Search_ValidRequest_ReturnsOkWithHolidays()
    {
        // Arrange
        var validRequest = new HolidaySearchRequest
        {
            DepartingFrom = "MAN",
            TravellingTo = "PMI"
        };

        var expectedResponse = new HolidaySearchResponse
        {
            Flights = new List<Flight>
            {
                new Flight { Id = 3, Airline = "Trans American Airlines", From = "MAN", To = "PMI", Price = 170, DepartureDate = "2023-06-15" }
            },
            Hotels = new List<Hotel>
            {
                new Hotel { Id = 3, Name = "Sol Katmandu Park & Resort", ArrivalDate = "2023-06-15", PricePerNight = 59, LocalAirports = [ "PMI" ], Nights = 14 }
            }
        };

        _holidaySearchServiceMock.Setup(service => service.Search(validRequest)).Returns(expectedResponse);

        // Act
        var result = await _controller.Search(validRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResponse, okResult.Value);
        _holidaySearchServiceMock.Verify(service => service.Search(validRequest), Times.Once);
    }
}