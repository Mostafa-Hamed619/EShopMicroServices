
namespace Catalog.API.Products.GetProductById;

public record GetProductByIdResponse(Product product);

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var product = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(product);
        }).WithName("GetProductById")
        .WithSummary("Getting product using it's id")
        .WithDescription("Getting product using it's id")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}

