using PrepayPower.Application.Offers;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.UnitTests.Offers;

public class TomatoOfferTests
{
    [Test]
    public void OneFreeAfterFive_Bought4_Returns0EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 1), 4)
        });
        
        // Act
        var actualDiscount = TomatoOffers.OneFreeAfterFive.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(0));
    }

    [Test]
    public void OneFreeAfterFive_Bought5_Returns1EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 1), 5)
        });
        
        // Act
        var actualDiscount = TomatoOffers.OneFreeAfterFive.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(1));
    }
    
    [Test]
    public void OneFreeAfterFive_Bought13_Returns1EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 1), 13)
        });
        
        // Act
        var actualDiscount = TomatoOffers.OneFreeAfterFive.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(1));
    }
    
    [Test]
    public void OneFreeAfterFive_Bought7ButInMultiplLines_Returns1EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 1), 4),
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 13),
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 1), 3)
        });
        
        // Act
        var actualDiscount = TomatoOffers.OneFreeAfterFive.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(1));
    }
}