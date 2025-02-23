﻿namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryCommandHandler
        (IDocumentSession session, ILogger<GetProductsQueryCommandHandler> logger) 
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handler called with {@Query}", query);

            var product = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(product);
        }
    }
}
