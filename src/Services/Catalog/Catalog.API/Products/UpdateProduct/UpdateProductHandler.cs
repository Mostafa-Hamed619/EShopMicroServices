namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, string ImageFile, List<string> Catalog, string Description, decimal price) 
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> _logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductQueryHandler cailed {@Command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product == null)
        {
            throw new ProductNotFoundException();
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

