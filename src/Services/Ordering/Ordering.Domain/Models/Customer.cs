using Ordering.Domain.Abstraction;

namespace Ordering.Domain.Models;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public static Customer AddCustomer(CustomerId Id, string Name, string Email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(Email);

        var Customer = new Customer
        {
            Id = Id,
            Name = Name,
            Email = Email
        };

        return Customer;
    }
}
