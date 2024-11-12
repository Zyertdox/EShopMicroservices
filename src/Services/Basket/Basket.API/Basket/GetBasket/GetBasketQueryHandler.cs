using Basket.API.Data;

namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketQueryResult>;

public record GetBasketQueryResult(ShoppingCart Cart);

public class GetBasketQueryHandler(IBasketRepository repository): IQueryHandler<GetBasketQuery, GetBasketQueryResult>
{
    public async Task<GetBasketQueryResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasket(request.UserName, cancellationToken);
        return new GetBasketQueryResult(basket);
    }
}