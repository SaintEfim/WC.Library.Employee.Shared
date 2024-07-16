namespace WC.Library.Employee.Shared.Exceptions;

public class EmployeeRegistrationException : Exception
{
    public EmployeeRegistrationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}