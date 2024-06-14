using FluentValidation;
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
            .Matches(@"^\S*$")
            .WithName(propertyName);

        RuleFor(x => x)
            .EmailAddress()
            .WithName(propertyName);

        RuleFor(x => x)
            .Custom((email, context) =>
            {
                var domain = email.Split('@').LastOrDefault();

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