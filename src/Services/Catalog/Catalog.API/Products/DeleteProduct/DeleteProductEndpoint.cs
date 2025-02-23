namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);

    public record DeleteProductResponse(bool isSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products", async (DeleteProductRequest request, ISender sender) =>
            {
                try
                {
                    var command = request.Adapt<DeleteProductCommand>();

                    var result = await sender.Send(command);

                    var response = result.Adapt<DeleteProductResponse>();

                    return Results.Ok(response);
                }
                catch
                {
                    return Results.Content("Server Error");
                }
            })
                .WithName("DeleteProducts")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete Products")
                .WithDescription("Delete Products");
        }
    }
}
