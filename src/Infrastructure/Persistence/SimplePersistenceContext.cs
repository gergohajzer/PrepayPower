using PrepayPower.Application.Common.Interfaces;
using PrepayPower.Domain.Entities;

namespace PrepayPower.Infrastructure.Persistence;

/// <summary>
/// A simple persistence context implementation.
/// </summary>
public class SimplePersistenceContext : IPersistenceContext
{
    public SimplePersistenceContext()
    {
        Purchases = new List<Purchase>();
        Vegetables = new List<Vegetable>();
    }

    public IEnumerable<Purchase> Purchases { get; set; }
    public IEnumerable<Vegetable> Vegetables { get; set; }
}