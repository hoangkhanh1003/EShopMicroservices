﻿namespace Catalog.API.Products.GetProducts
{
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                try
                {
                    GetProductsResult result = await sender.Send(new GetProductsQuery());

                    GetProductsResponse response = result.Adapt<GetProductsResponse>();

                    return Results.Ok(response);
                }
                catch
                {
                    return Results.Content("Server Error");
                }
            })
                .WithName("GetProducts")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
        }
    }
}
