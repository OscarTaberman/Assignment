using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    ProductResult CreateProduct(Product product);
    ProductResult<IEnumerable<Product>> ReadAllProducts();
    ProductResult UpdateProduct(Product product);
    ProductResult DeleteProduct(Product product);
}
