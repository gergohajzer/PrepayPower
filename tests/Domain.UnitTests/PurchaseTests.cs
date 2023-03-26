using PrepayPower.Domain.Entities;
using PrepayPower.Domain.Exceptions;

namespace PrepayPower.Domain.UnitTests;

public class PurchaseTests
{
    [Test]
    public void Ctor_EmptyList_ThrowsEmptyPurchaseException()
    {
        FluentActions.Invoking(() => new Purchase(new List<PurchaseElement>()))
                    .Should().Throw<EmptyPurchaseException>();
    }
}