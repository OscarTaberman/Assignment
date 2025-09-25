using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    bool CreatePoduct(CreateProduct product);
    IEnumerable<ProductModel> GetAllProducts();
    ProductModel GetProduct(string id);
    bool UpdateProduct(string id, UpdateProduct product);
    bool DeleteProduct(string id);
}
