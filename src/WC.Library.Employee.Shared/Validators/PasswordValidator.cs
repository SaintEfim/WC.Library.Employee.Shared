using FluentValidation;
using WC.Library.Shared.Constants;

namespace WC.Library.Employee.Shared.Validators;

public class PasswordValidator : AbstractValidator<string>
{
    public PasswordValidator(string propertyName)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .NotEmpty()
            .WithName(propertyName);

        RuleFor(x => x)
            .MinimumLength(CommonConstants.GenericPasswordMinLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .MaximumLength(CommonConstants.GenericPasswordMaxLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .Matches(@"(?=.*\d)")
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one digit.");

        RuleFor(x => x)
            .Matches("(?=.*[a-z])")
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one lowercase letter.");

        RuleFor(x => x)
            .Matches("(?=.*[A-Z])")
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one uppercase letter.");

        RuleFor(x => x)
            .Matches("[!@#$%^&*()-+=]")
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one special character.");

        RuleFor(x => x)
            .Matches(@"^\S*$")
            .WithName(propertyName)
            .WithMessage($"{propertyName} cannot contain whitespace characters.");
    }
}