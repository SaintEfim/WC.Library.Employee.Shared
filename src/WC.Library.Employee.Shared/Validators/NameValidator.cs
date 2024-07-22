using FluentValidation;
using WC.Library.Shared.Constants;

namespace WC.Library.Employee.Shared.Validators;

public class NameValidator : AbstractValidator<string>
{
    public NameValidator(
        string propertyName)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .NotEmpty()
            .WithName(propertyName);

        RuleFor(x => x)
            .MinimumLength(CommonConstants.GenericNameMinLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .MaximumLength(CommonConstants.GenericNameMaxLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .Matches("^[А-ЯЁ][а-яё]*$")
            .WithName(propertyName)
            .WithMessage(
                $"{propertyName} must start with an uppercase letter followed by lowercase letters, all in Cyrillic.");
    }
}
