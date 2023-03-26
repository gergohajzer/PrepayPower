using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Offers;

public static class TomatoOffers
{
    public const string VegetableName = "Tomato";

    /// <summary>
    /// One Tomato is free if he/she/it bought at least 5;
    /// </summary>
    /// <returns>Discount function</returns>
    public static Func<Purchase, double> OneFreeAfterFive => 
        p => p.Elements.Where(x => x.Vegetable.Name == VegetableName)
            .Sum(x => x.Quantity) >= 5
            ? p.Elements.First(x => x.Vegetable.Name == VegetableName).Vegetable.Price
            : 0.0;


}