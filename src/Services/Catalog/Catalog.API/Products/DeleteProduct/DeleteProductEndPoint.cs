
namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductResponse(bool IsSucess);

public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/product/{id}", async (Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(Id));

            var IsDeleted = result.Adapt<DeleteProductResponse>();

            return Results.Ok(IsDeleted);
        }).WithName("DeleteProduct")
        .WithDescription("Delete product")
        .Produces<Product>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
