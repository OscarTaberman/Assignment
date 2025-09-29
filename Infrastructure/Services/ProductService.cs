using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<ProductModel> _products = [];

    public Results CreatePoduct(CreateProduct product)
    {
        var newProduct = new ProductModel();
        {
            newProduct.Name = product.Name;
            newProduct.ArticleNumber = product.ArticleNumber;
            newProduct.Description = product.Description;
            newProduct.Price = product.Price;
        }

        _products.Add(newProduct);

        return new Results<ProductModel>
        {
            Success = true,
            Error = null,
        };
    }

    Results<IEnumerable<ProductModel>> IProductService.ShowAllProducts()
    {
        throw new NotImplementedException();
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
