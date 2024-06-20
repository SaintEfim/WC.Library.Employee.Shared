using FluentValidation;
using WC.Library.Employee.Shared.ConstantsRegex;
using WC.Library.Shared.Constants;

namespace WC.Library.Employee.Shared.Validators;

public class PositionValidator : AbstractValidator<string>
{
    public PositionValidator(string propertyName)
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithName(propertyName);

        RuleFor(x => x)
            .MinimumLength(CommonConstants.GenericPositionMinLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .MaximumLength(CommonConstants.GenericPositionMaxLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .Matches(@"^[А-ЯЁ][\u0400-\u04FF\s.,!?;:()\-]*$")
            .WithName(propertyName);
    }
}