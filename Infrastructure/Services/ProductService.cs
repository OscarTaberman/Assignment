using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<ProductModel> _products = [];

    public Response CreateProduct(CreateProduct product)
    {
        var newProduct = new ProductModel
        {
            Name = product.Name,
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Price = product.Price,
        };

        _products.Add(newProduct);

        return new Response<ProductModel>
        {
            Success = true,
            Error = null,
            Data = newProduct
        };
    }

    public Response<IEnumerable<ProductModel>> ReadAllProducts(ProductModel product)
    {
        var productList = new ProductModel()
        {
            Id = product.Id,
            Name = product.Name,
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Price = product.Price,
        };

        return new Response<IEnumerable<ProductModel>>
        {
            Success = true,
            Error = null,
        };
    }

    public ProductModel GetProduct(string id)
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
