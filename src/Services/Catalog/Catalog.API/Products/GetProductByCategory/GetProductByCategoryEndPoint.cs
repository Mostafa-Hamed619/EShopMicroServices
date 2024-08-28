namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

public class GetProductByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{Catalog}", async (string Catalog, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(Catalog));

            var products = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(products);
        }).WithName("GetProductByCategory")
        .WithDescription("getting products using it's category")
        .Produces<IEnumerable<Product>>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
