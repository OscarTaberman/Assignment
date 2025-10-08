using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly List<ProductModel> _products = [];
    private readonly IGuidGenerator _guidGenerator;

    public ProductService(IGuidGenerator guidGenerator)
    {
        _guidGenerator = guidGenerator;
    }

    public Response CreateProduct(CreateProduct product)
    {
        var newProduct = new ProductModel
        {
            Id = _guidGenerator.GenerateGuid(),
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
        return new Response<IEnumerable<ProductModel>>
        {
            Success = true,
            Data = _products,
        };
    }

    public Response<ProductModel> GetProductById(string id)
    {
        var productById = _products.FirstOrDefault(p => p.Id == id);

        if (productById is null)
        {
            return new Response<ProductModel>
            {
                Success = false,
                Error = $"No product found with: {id}"
            };
        }
        return new Response<ProductModel>
        {
            Success = true,
            Data = productById
        };
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
