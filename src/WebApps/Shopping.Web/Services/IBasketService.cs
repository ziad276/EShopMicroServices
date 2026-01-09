
namespace Shopping.Web.Services
{
    public interface IBasketService
    {
        [Get("/basket-service/basket/{userName}")]
        Task<GetBasketResponse> GetBasket(string UserName);

        [Post("/basket-service/basket}")]
        Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

        [Delete("/basket-service/basket/{userName}")]
        Task<DeleteBasketResponse> DeleteBasket(string UserName);

        [Post("/basket-service/basket/checkout}")]
        Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);

    }
}
