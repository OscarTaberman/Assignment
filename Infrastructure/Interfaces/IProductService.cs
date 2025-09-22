using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    bool CreatePoduct(CreateProduct product);
    IEnumerable<BaseProduct> GetAllProducts();
    bool UpdateProduct(BaseProduct product);
    bool DeleteProduct();
}
