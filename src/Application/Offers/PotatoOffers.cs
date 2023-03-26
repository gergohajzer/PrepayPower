using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Offers;

public static class PotatoOffers
{
    public const string VegetableName = "Potato";
    
    /// <summary>
    /// Every third potato is discounted.
    /// </summary>
    /// <returns>Discount function</returns>
    public static Func<Purchase, double> EveryThirdIsFree => 
        // ReSharper disable once PossibleLossOfFraction
        p => p.Elements.Where(x => x.Vegetable.Name == VegetableName)
            .Sum(x => x.Quantity) / 3;
}