namespace PrepayPower.Domain.Exceptions;

public class EmptyPurchaseException : Exception
{
    public EmptyPurchaseException(string message)
        : base(message) { }
}