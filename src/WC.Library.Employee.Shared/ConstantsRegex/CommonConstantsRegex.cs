namespace WC.Library.Employee.Shared.ConstantsRegex;

public static class CommonConstantsRegex
{
    public const string GenericNoWhitespaceRegex = @"^\S*$";

    public const string GenericContainsCyrillicNameRegex = "^[А-ЯЁ][а-яё]*$";
}