namespace WC.Library.Employee.Shared.Exceptions;

public class AuthenticationFailedException : Exception
{
    public AuthenticationFailedException()
    {
    }

    public AuthenticationFailedException(string message) : base(message)
    {
    }
}