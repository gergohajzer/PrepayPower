namespace PrepayPower.Domain.Entities;

/// <summary>
/// An offer or discount that belongs to a purchase.
/// </summary>
public class PurchaseOffer
{
    public PurchaseOffer(string promoCode, string description, double discount)
    {
        PromoCode = promoCode;
        Description = description;
        Discount = discount;
    }

    public string PromoCode { get; }

    public string Description { get; }
    
    public double Discount { get; }
}