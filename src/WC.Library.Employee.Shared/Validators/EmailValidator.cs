using FluentValidation;
using WC.Library.Employee.Shared.ConstantsRegex;
using WC.Library.Shared.Constants;

namespace WC.Library.Employee.Shared.Validators;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator(string propertyName)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .NotEmpty()
            .WithName(propertyName);

        RuleFor(x => x)
            .MinimumLength(CommonConstants.GenericEmailMinLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .MaximumLength(CommonConstants.GenericEmailMaxLength)
            .WithName(propertyName);

        RuleFor(x => x)
            .Matches(CommonConstantsRegex.GenericNoWhitespaceRegex)
            .WithName(propertyName)
            .WithMessage($"{propertyName} cannot contain whitespace characters.");

        RuleFor(x => x)
            .Must(x => x.IndexOf(CommonConstants.GenericAtSymbol) != -1 && x.IndexOf(CommonConstants.GenericAtSymbol) ==
                x.LastIndexOf(CommonConstants.GenericAtSymbol))
            .WithName(propertyName)
            .WithMessage($"{propertyName} must contain exactly one '@' symbol.");

        RuleFor(x => x)
            .Custom((email, context) =>
            {
                var domain = email.Split(CommonConstants.GenericAtSymbol).LastOrDefault();

                var allowedDomains = new List<string>
                {
                    "gmail.com",
                    "mail.ru",
                    "yahoo.com",
                    "hotmail.com",
                    "outlook.com",
                    "yandex.ru",
                    "protonmail.com",
                    "aol.com",
                    "icloud.com",
                    "zoho.com"
                };

                if (domain != null && !allowedDomains.Contains(domain))
                {
                    context.AddFailure($"Invalid domain '{domain}'");
                }
            });
    }
}