using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Results CreateProduct(CreateProduct product);
    Results<IEnumerable<ProductModel>> ShowAllProducts(ProductModel product);
    ProductModel GetAProduct(string id);
    bool UpdateProduct(string id, UpdateProduct product);
    bool DeleteProduct(string id);
}
