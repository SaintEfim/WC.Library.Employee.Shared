using FluentValidation;

namespace WC.Library.Employee.Shared.Validators;

public class EmailValidator : AbstractValidator<string>
{
    public EmailValidator(
        string propertyName)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .NotEmpty()
            .WithName(propertyName);

        RuleFor(x => x)
            .Matches(
                @"(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)| copy         ("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))")
            .WithName(propertyName);
    }
}
