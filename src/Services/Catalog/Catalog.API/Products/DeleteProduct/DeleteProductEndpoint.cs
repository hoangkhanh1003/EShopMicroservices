﻿namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);

    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                try
                {
                    var result = await sender.Send(new DeleteProductCommand(id));

                    var response = result.Adapt<DeleteProductResponse>();

                    return Results.Ok(response);
                }
                catch(Exception ex)
                {
                    if (ex is ProductNotFoundException product)
                    {
                        return Results.NotFound(product.Message);
                    }

                    return Results.Content("Server Error");
                }
            })
                .WithName("DeleteProducts")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Delete Products")
                .WithDescription("Delete Products");
        }
    }
}
