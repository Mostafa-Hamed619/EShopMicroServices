using FluentValidation;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, string ImageFile, List<string> Catalog, string Description, decimal price) 
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidation()
    {
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 15).WithMessage("Name must be between 2 and 15 legnth");

        RuleFor(command => command.price)
            .GreaterThan(0).WithMessage("price must be greater than 0");

    }
} 

public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException(command.Id);
        }
        product.Name = command.Name;
        product.ImageFile = command.ImageFile;
        product.Description = command.Description;
        product.Catalog = command.Catalog;
        product.Price = command.price;

        session.Update(product);
        await session.SaveChangesAsync();
        return new UpdateProductResult(true);
    }
}

