using Infrastructure.Interfaces;
using Infrastructure.Models;


namespace ProductService;

public class ProductService
{
    public ProductService(BaseProduct product)
    {
        return new ProductResult
        {
            Success = true,
            Error = false,
        };
    }

    public string DeleteProduct(BaseProduct product)
    {
        return new ProductResult
        {
            Success = true,
            Error = false,
        };
    }

    public ProductResult<IEnumerable<BaseProduct>> ReadAllProducts()
    {
        return new ProductResult<IEnumerable<BaseProduct>>();

    }

    public UpdateProduct(BaseProduct product)
    {
        return new ProductResult
        {
            Success = true,
            Error = false,
        };
    }
}