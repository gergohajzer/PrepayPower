namespace PrepayPower.Domain.Exceptions;

public class InvalidVegetablePriceException : Exception
{
    public InvalidVegetablePriceException(string message)
        : base(message) { }
}