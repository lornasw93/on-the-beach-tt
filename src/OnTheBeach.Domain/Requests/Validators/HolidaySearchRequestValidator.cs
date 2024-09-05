using FluentValidation;

namespace OnTheBeach.Domain.Requests.Validators;

public class HolidaySearchRequestValidator : AbstractValidator<HolidaySearchRequest>
{
    public HolidaySearchRequestValidator()
    {
        RuleFor(r => r.DepartingFrom).Length(1, 3).NotEmpty();
        RuleFor(r => r.TravellingTo).Length(1, 3).NotEmpty(); 
    }
}
