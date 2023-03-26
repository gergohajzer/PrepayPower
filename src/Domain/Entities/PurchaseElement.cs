namespace PrepayPower.Domain.Entities;

/// <summary>
/// Represents a vegetable that is purchased by someone.
/// </summary>
public class PurchaseElement
{
    public PurchaseElement(Vegetable vegetable, int quantity)
    {
        Vegetable = vegetable;
        Quantity = quantity;
    }

    public Vegetable Vegetable { get; set; }

    public int Quantity { get; set; }
}