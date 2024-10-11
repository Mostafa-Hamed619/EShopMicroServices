using Ordering.Domain.Abstraction;
using System.Linq.Expressions;

namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }

    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var product = new Product {Id = id, Name = name, Price = price };
        return product;
    }
}
