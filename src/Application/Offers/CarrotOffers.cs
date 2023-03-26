using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Offers;

public class CarrotOffers
{
    public const string VegetableName = "Carrot";

    /// <summary>
    /// For every 5€ spent on Carrots, it counts the discount.
    /// </summary>
    /// <returns>Discount function</returns>
    public static Func<Purchase, double> AfterEvery5EurDeduct1Eur => 
        p => (int) (p.Elements.Where(x => x.Vegetable.Name == VegetableName)
                .Sum(x => x.Quantity * x.Vegetable.Price) / 5);
}