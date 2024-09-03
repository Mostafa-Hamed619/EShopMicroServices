namespace Basket.API.Basket.StoreBasket;

public record StoreBasketRequest(ShoppingCart Cart);

public record StoreBasketResponse(string UserName);

public class StoreBasketEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBasketRequest request, ISender Sender) =>
        {
            var command = request.Adapt<StoreBasketCommand>();

            var result = await Sender.Send(command);

            var response = result.Adapt<StoreBasketResponse>();

            return Results.Ok(response);

        }).WithName("CreateProductBasket")
        .WithDescription("Creating product basket")
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .Produces<StoreBasketResponse>(StatusCodes.Status200OK);

    }
}
