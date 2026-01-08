using Shopping.Web.Models.Basket;

namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        Task<GetBasketResponse> GetBasket(ShoppingCartModel Cart);
        public record StoreBasketResponse(string UserName);
        public record DeleteBasketResponse(bool IsSuccess);

    }
}
