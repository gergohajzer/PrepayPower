namespace PrepayPower.Domain.Entities;

/// <summary>
/// Represents an offer or a discount in the shop.
/// </summary>
public class Offer
{
    public Offer(string promoCode, string description, Func<Purchase, double> calculateDiscountFn)
    {
        PromoCode = promoCode;
        Description = description;
        CalculateDiscount = calculateDiscountFn;    
    }

    public string PromoCode { get; set; }

    public string Description { get; set; }

    public Func<Purchase, double> CalculateDiscount { get; set; }
}