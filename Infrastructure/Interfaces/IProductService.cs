using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Response CreateProduct(CreateProduct product);
    Response<IEnumerable<ProductModel>> ReadAllProducts(ProductModel product);
    ProductModel GetProduct(string id);
    bool UpdateProduct(string id, UpdateProduct product);
    bool DeleteProduct(string id);
}
