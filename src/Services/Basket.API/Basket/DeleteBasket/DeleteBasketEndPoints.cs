namespace Basket.API.Basket.DeleteBasket;

//public record DeleteBasketRequest(string UserName);

public record DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndPoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string UserName, ISender Sender) =>
        {
            var result = await Sender.Send(new DeleteBasketCommand(UserName));

            var response = result.Adapt<DeleteBasketResponse>();

            return Results.Ok(response);
  
        }).WithName("DeleteProductBasket")
        .WithDescription("Deleting product basket")
        .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
