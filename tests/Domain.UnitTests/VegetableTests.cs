using PrepayPower.Domain.Entities;
using PrepayPower.Domain.Exceptions;

namespace PrepayPower.Domain.UnitTests;

public class VegetableTests
{
    [Test]
    public void Ctor_NegativePrice_ThrowsInvalidVegetablePriceException()
    {
        FluentActions.Invoking(() => new Vegetable("Tomato", -3.3))
            .Should().Throw<InvalidVegetablePriceException>();
    }
    
    [Test]
    public void Ctor_ZeroPrice_ThrowsInvalidVegetablePriceException()
    {
        FluentActions.Invoking(() => new Vegetable("Tomato", 0))
            .Should().Throw<InvalidVegetablePriceException>();
    }
}