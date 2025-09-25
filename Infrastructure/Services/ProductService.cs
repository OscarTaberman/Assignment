using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    public bool CreatePoduct(CreateProduct product)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductModel> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public ProductModel GetProduct(string id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(string id, UpdateProduct product)
    {
        throw new NotImplementedException();
    }
}
