using PrepayPower.Domain.Entities;

namespace PrepayPower.Application.Common.Interfaces;

public interface IPersistenceContext
{
    public IEnumerable<Purchase> Purchases { get; set; }
    
    public IEnumerable<Vegetable> Vegetables { get; set; }
}