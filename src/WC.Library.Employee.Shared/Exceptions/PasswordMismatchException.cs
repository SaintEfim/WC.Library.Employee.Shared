namespace WC.Library.Employee.Shared.Exceptions;

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException(string message)
        : base(message)
    {
    }
}