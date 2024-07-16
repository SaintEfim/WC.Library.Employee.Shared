namespace WC.Library.Employee.Shared.Exceptions;

public class PositionNotFoundException : Exception
{
    public PositionNotFoundException(string message)
        : base(message)
    {
    }
}