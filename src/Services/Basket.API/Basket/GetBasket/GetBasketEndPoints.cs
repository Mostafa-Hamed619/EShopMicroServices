
namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShoppingCart Cart);

public class GetBasketEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string UserName, ISender Sender) =>
        {
            var result = await Sender.Send(new GetBasketQuery(UserName));

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        }).WithName("GetBasketByUserName")
        .WithDescription("Getting Basket Using UserName")
        .Produces<ShoppingCart>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
