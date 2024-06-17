using FluentValidation;
using WC.Library.Employee.Shared.ConstantsRegex;
using WC.Library.Shared.Constants;

namespace WC.Library.Employee.Shared.Validators;

public class NameValidator : AbstractValidator<string>
{
    private const string ContainsNoNumbersOrSpecialCharactersRegex = "^[^0-9!@#$%^&*()_+=-]*$";

    public NameValidator(string propertyName)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .NotEmpty()
            .WithName(propertyName)
            .WithMessage($"{propertyName} cannot be empty.");

        RuleFor(x => x)
            .MinimumLength(CommonConstants.GenericNameMinLength)
            .WithName(propertyName)
            .WithMessage($"{propertyName} must be at least 2 characters long.");

        RuleFor(x => x)
            .MaximumLength(CommonConstants.GenericNameMaxLength)
            .WithName(propertyName)
            .WithMessage($"{propertyName} must be at most 50 characters long.");

        RuleFor(x => x)
            .Matches(CommonConstantsRegex.GenericContainsCyrillicNameRegex)
            .WithName(propertyName)
            .WithMessage(
                $"{propertyName} must start with an uppercase letter followed by lowercase letters, all in Cyrillic.");

        RuleFor(x => x)
            .Matches(ContainsNoNumbersOrSpecialCharactersRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} cannot contain numbers or special characters.");
    }
}