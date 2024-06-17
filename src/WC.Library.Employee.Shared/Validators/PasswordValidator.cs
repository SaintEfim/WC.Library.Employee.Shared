using FluentValidation;
using WC.Library.Employee.Shared.ConstantsRegex;
using WC.Library.Shared.Constants;

namespace WC.Library.Employee.Shared.Validators;

public class PasswordValidator : AbstractValidator<string>
{
    private const string ContainsDigitRegex = @"(?=.*\d)";
    private const string ContainsLowercaseRegex = "(?=.*[a-z])";
    private const string ContainsUppercaseRegex = "(?=.*[A-Z])";
    private const string ContainsSpecialCharRegex = "[!@#$%^&*()-+=]";

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
            .Matches(CommonConstantsRegex.GenericNoWhitespaceRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} cannot contain whitespace characters.");

        RuleFor(x => x)
            .Matches(ContainsDigitRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one digit.");

        RuleFor(x => x)
            .Matches(ContainsLowercaseRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one lowercase letter.");

        RuleFor(x => x)
            .Matches(ContainsUppercaseRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one uppercase letter.");

        RuleFor(x => x)
            .Matches(ContainsSpecialCharRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain at least one special character.");
    }
}