using PrepayPower.Application.Offers;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.UnitTests.Offers;

public class CarrotOfferTests
{
    [Test]
    public void AfterEvery5EurDeduct1Eur_Paid4Eur_Returns0EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(CarrotOffers.VegetableName, 1), 4)
        });
        
        // Act
        var actualDiscount = CarrotOffers.AfterEvery5EurDeduct1Eur.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(0));
    }
    
    [Test]
    public void AfterEvery5EurDeduct1Eur_Paid7Eur_Returns1EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(CarrotOffers.VegetableName, 1), 7)
        });
        
        // Act
        var actualDiscount = CarrotOffers.AfterEvery5EurDeduct1Eur.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(1));
    }
    
    [Test]
    public void AfterEvery5EurDeduct1Eur_Paid10Eur_Returns2EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(CarrotOffers.VegetableName, 1), 10)
        });
        
        // Act
        var actualDiscount = CarrotOffers.AfterEvery5EurDeduct1Eur.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(2));
    }
    
    [Test]
    public void AfterEvery5EurDeduct1Eur_Paid16EurWhileAddedCarrotMultipleTimes_Returns3EurDiscount()
    {
        // Arrange
        var purchase = new Purchase(new List<PurchaseElement>
        {
            new PurchaseElement(new Vegetable(CarrotOffers.VegetableName, 1), 3),
            new PurchaseElement(new Vegetable(TomatoOffers.VegetableName, 3), 30),
            new PurchaseElement(new Vegetable(CarrotOffers.VegetableName, 1), 6),
            new PurchaseElement(new Vegetable(PotatoOffers.VegetableName, 2), 30),
            new PurchaseElement(new Vegetable(CarrotOffers.VegetableName, 1), 7),
        });
        
        // Act
        var actualDiscount = CarrotOffers.AfterEvery5EurDeduct1Eur.Invoke(purchase);
        
        // Assert
        Assert.That(actualDiscount, Is.EqualTo(3));
    }
}