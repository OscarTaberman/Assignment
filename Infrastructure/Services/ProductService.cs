using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<ProductModel> _products = [];

    public Results CreateProduct(CreateProduct product)
    {
        var newProduct = new ProductModel
        {
            Name = product.Name,
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Price = product.Price,
        };

        _products.Add(newProduct);

        return new Results<ProductModel>
        {
            Success = true,
            Error = null,
            Data = newProduct
        };
    }

    public Results<IEnumerable<ProductModel>> ShowAllProducts(ProductModel product)
    {
        var productList = new ProductModel()
        {
            Name = product.Name,
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Price = product.Price,
        };

        return new Results<IEnumerable<ProductModel>>
        {
            Success = true,
            Error = null,
        };
    }

    public ProductModel GetAProduct(string id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(string id, UpdateProduct product)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }
}
