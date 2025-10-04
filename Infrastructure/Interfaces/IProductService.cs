using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Response CreateProduct(CreateProduct product);
    Response<IEnumerable<ProductModel>> ShowAllProducts(ProductModel product);
    ProductModel GetAProduct(string id);
    bool UpdateProduct(string id, UpdateProduct product);
    bool DeleteProduct(string id);
}
