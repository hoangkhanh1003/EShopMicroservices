namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuey(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);

    public class GetBasketHandler(IBasketRepository repository)
        : IQueryHandler<GetBasketQuey, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuey query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(query.UserName);

            return new GetBasketResult(basket);
        }
    }
}
