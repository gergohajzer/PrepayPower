using PrepayPower.Domain.Exceptions;

namespace PrepayPower.Domain.Entities;

/// <summary>
/// Represents a vegetable in the shop.
/// </summary>
public class Vegetable
{
    public Vegetable(string name, double price)
    {
        if (price <= 0)
            throw new InvalidVegetablePriceException("Vegetable can not be created. Price should be greater than 0.");
            
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    
    
}