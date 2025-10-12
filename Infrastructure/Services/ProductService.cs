using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Xml.Linq;


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
        if (_products.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return new Response
            {
                Success = false,
                Error = "The product name already exists",
            };
        }

        var newProduct = new ProductModel
        {
            Id = _guidGenerator.GenerateGuid(),
            Name = product.Name,
            ArticleNumber = product.ArticleNumber,
            Description = product.Description,
            Price = product.Price,
        };


        if (!string.IsNullOrWhiteSpace(product.Name))
        {
            _products.Add(newProduct);
        }

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

    public Response<ProductModel> GetProductByArticleNumber(string number)
    {
        var productByArticleNumber = _products.FirstOrDefault(an => an.ArticleNumber == number);

        if (productByArticleNumber is null)
        {
            return new Response<ProductModel>
            {
                Success = false,
                Error = $"No product found with: {number}"
            };
        }
        return new Response<ProductModel>
        {
            Success = true,
            Data = productByArticleNumber
        };
    }

    public Response<ProductModel> GetProductByName(string name)
    {
        var productByName = _products.FirstOrDefault(n => n.Name == name);

        if (productByName is null)
        {
            return new Response<ProductModel>
            {
                Success = false,
                Error = $"No product found with: {name}"
            };
        }
        return new Response<ProductModel>
        {
            Success = true,
            Data = productByName
        };
    }

    public Response<ProductModel> UpdateProduct(string name, UpdateProduct product)
    {
        var productByName = _products.FirstOrDefault(n => n.Name == name);

        if (productByName is null)
        {
            return new Response<ProductModel>
            {
                Success = false,
                Error = $"No product found with: {name}"
            };
        }

        productByName.Name = product.Name;
        productByName.ArticleNumber = product.ArticleNumber;
        productByName.Description = product.Description;
        productByName.Price = product.Price;

        return new Response<ProductModel>
        {
            Success = true,
            Data = productByName
        };
    }

    public Response<ProductModel> DeleteProduct(string name)
    {
        var productByName = _products.FirstOrDefault(n => n.Name == name);
        
        if (productByName is null)
        {
            return new Response<ProductModel>
            {
                Success = false,
                Error = $"No product found with: {name}"
            };
        }

        return new Response<ProductModel>
        {
            Success = true
        };
    }
}
