

public record CreateProductCommand(string Name, string description, List<string> Catalogs, string ImageFile, decimal Price)
    :ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Create product entity from command object.
        //Save to database.
        //Return CreateProductResult result.

        var product = new Product()
        {
            Name = command.Name,
            Description = command.description,
            ImageFile = command.ImageFile,
            Price = command.Price,
            Catalog = command.Catalogs
        };
        //save to database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
