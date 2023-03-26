using PrepayPower.Application.Purchases.Queries;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.UnitTests.Purchases.Queries;

public class GetReceiptForPurchaseTests
{
    [Test]
    public async Task GetReceiptForPurchaseQuery_PurchasedTomatoes_ContainsTomatoAndPrice()
    {
        //Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new(new Vegetable("Tomato", 3.4), 3),
        });
        var command = new GetReceiptForPurchaseCommand(purchase);
        var handler = new GetReceiptForPurchaseCommandHandler();
        
        //Act
        var receipt = await handler.Handle(command, new CancellationToken());

        //Assert
        StringAssert.Contains("Tomato", receipt);
        StringAssert.Contains("EUR3.4", receipt);
    }
    
    [Test]
    public async Task GetReceiptForPurchaseQuery_NoDiscountedProducts_ReceiptContainsNoDiscount()
    {
        //Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new(new Vegetable("Tomato", 3.4), 3),
        });
        var command = new GetReceiptForPurchaseCommand(purchase);
        var handler = new GetReceiptForPurchaseCommandHandler();
        
        //Act
        var receipt = await handler.Handle(command, new CancellationToken());

        //Assert
        StringAssert.DoesNotContain("Sub-total:", receipt);
        StringAssert.DoesNotContain("Discounts:", receipt);
    }
}