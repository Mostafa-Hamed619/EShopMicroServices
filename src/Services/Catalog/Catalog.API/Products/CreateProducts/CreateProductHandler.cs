

using FluentValidation;

public record CreateProductCommand(string Name, string description, List<string> Catalogs, string ImageFile, decimal Price)
    :ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
            .Length(2,15).WithMessage("Name must be between 2 and 15 length");
        RuleFor(x => x.description).NotEmpty().WithMessage("description is required");
        RuleFor(x => x.Catalogs).NotEmpty().WithMessage("Catalog is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image is required");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
    }
}

public class CreateProductHandler(IDocumentSession session, IValidator<CreateProductCommand> validator)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        
        var result = await validator.ValidateAsync(command, cancellationToken);
        var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
        if (errors.Any())
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

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
