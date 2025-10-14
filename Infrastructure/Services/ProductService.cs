using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using Infrastructure.Models;


namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private List<ProductModel> _productList = [];
    private readonly IGuidGenerator _guidGenerator;
    private readonly JsonFileService _fileService;

    public ProductService(IGuidGenerator guidGenerator, IFileRepository fileRepository)
    {
        _guidGenerator = guidGenerator;
        _fileService = (JsonFileService)fileRepository;

        var response = _fileService.ReadFromFile<List<ProductModel>>();
        if (response.Success && response.Data is not null)
            _productList = response.Data;
        else
            _productList = [];
    }

    public Response CreateProduct(CreateProduct product)
    {
        if (_productList.Any(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase)))
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
        
        _productList.Add(newProduct);

        var saveProduct = _fileService.SaveProductToFile(_productList);

        return new Response<ProductModel>
        {
            Success = saveProduct.Success,
            Error = saveProduct.Error,
            Data = saveProduct.Success ? newProduct : null
        };
    }

    public Response<IEnumerable<ProductModel>> ReadAllProducts(ProductModel product)   
    {
        return new Response<IEnumerable<ProductModel>>
        {
            Success = true,
            Data = _productList,
        };
    }

    public Response<ProductModel> GetProductByName(string name)
    {
        var productByName = _productList.FirstOrDefault(n => n.Name == name);

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

    public Response<ProductModel> GetProductByArticleNumber(string number)
    {
        var productByArticleNumber = _productList.FirstOrDefault(an => an.ArticleNumber == number);

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


    public Response<ProductModel> UpdateProduct(string name, UpdateProduct product)
    {
        var productByName = _productList.FirstOrDefault(n => n.Name == name);

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

        _fileService.SaveProductToFile(_productList);

        return new Response<ProductModel>
        {
            Success = true,
            Data = productByName
        };
    }

    public Response<ProductModel> DeleteProduct(string name)
    {
        var productByName = _productList.FirstOrDefault(n => n.Name == name);
        
        if (productByName is null)
        {
            return new Response<ProductModel>
            {
                Success = false,
                Error = $"No product found with: {name}"
            };
        }

        _productList.Remove(productByName);

        _fileService.SaveProductToFile(_productList);

        return new Response<ProductModel>
        {
            Success = true
        };
    }
}
