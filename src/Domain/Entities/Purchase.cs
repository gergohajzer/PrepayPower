using PrepayPower.Domain.Exceptions;

namespace PrepayPower.Domain.Entities;

/// <summary>
/// Represents information about a purchase.
/// </summary>
public class Purchase
{
    public Purchase(IList<PurchaseElement> elements)
    {
        if (elements.Count == 0)
        {
            throw new EmptyPurchaseException("Purchase can not be created without any element.");
        }
        Elements= elements.AsReadOnly();
        Date = DateTime.Now;
        AppliedOffers = new List<PurchaseOffer>();
    }
    
    public IReadOnlyCollection<PurchaseElement> Elements { get; }

    public DateTime Date { get; set; }
    
    public double SubTotalPrice => Elements.Sum(x => x.Quantity * x.Vegetable.Price);
    
    public double TotalPrice => SubTotalPrice - AppliedOffers.Sum(x => x.Discount);

    public IList<PurchaseOffer> AppliedOffers { get; set; }
}