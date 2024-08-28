
namespace Catalog.API.Products.GetProducts;
public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductQuery());
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        }).WithName("get-products")
        .WithSummary("get the products from database")
        .WithDescription("get the products from database")
        .Produces<GetProductResult>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
