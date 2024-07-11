using FluentValidation;

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
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$")
            .WithName(propertyName);
    }
}