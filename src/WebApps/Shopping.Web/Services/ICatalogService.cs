
namespace Shopping.Web.Services
{
    public interface ICatalogService
    {
        Task<GetProductsRespone> GetProducts(int? pageNumber = 1, int? pageSize = 10);
        Task<GetProductByIdRespone> GetProduct(Guid id);
        Task<GetProductByCategoryRespone> GetProductsByCategory(string category);

    }

    
}
