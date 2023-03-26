using PrepayPower.Application.Offers;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.UnitTests.Offers;

public class PotatoOfferTests
{
    [Test]
    public void EveryThirdIsFree_Bought2_Returns0EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 2)
        });
        
        // Act
        var actualDiscount = PotatoOffers.EveryThirdIsFree.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(0));
    }

    [Test]
    public void EveryThirdIsFree_Bought3_Returns1EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 3)
        });
        
        // Act
        var actualDiscount = PotatoOffers.EveryThirdIsFree.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(1));
    }
    
    [Test]
    public void EveryThirdIsFree_Bought4_Returns1EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 4)
        });
        
        // Act
        var actualDiscount = PotatoOffers.EveryThirdIsFree.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(1));
    }
    
    [Test]
    public void EveryThirdIsFree_Bought8_Returns2EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 8)
        });
        
        // Act
        var actualDiscount = PotatoOffers.EveryThirdIsFree.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(2));
    }
    
    [Test]
    public void EveryThirdIsFree_Bought7ButInDifferentLines_Returns2EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 3),
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 1), 8),
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 1), 4),
        });
        
        // Act
        var actualDiscount = PotatoOffers.EveryThirdIsFree.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(2));
    }
}