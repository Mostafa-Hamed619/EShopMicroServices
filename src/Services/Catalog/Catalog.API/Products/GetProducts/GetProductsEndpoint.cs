﻿namespace Catalog.API.Products.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request,ISender sender) =>
        {
            var query = request.Adapt<GetProductQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);
        }).WithName("get-products")
        .WithSummary("get the products from database")
        .WithDescription("get the products from database")
        .Produces<GetProductResult>()
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
