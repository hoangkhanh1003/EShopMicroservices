namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryCommandHandler(IDocumentSession session) 
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>().ToPagedListAsync(
                query.PageNumber,
                query.PageSize,
                cancellationToken);

            return new GetProductsResult(product);
        }
    }
}
