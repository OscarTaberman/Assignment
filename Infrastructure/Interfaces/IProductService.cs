using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Response CreateProduct(CreateProduct product);
    Response<IEnumerable<ProductModel>> ReadAllProducts(ProductModel product);
    Response<ProductModel> GetProductByArticleNumber(string articlenumber);
    Response<ProductModel> GetProductByName(string name);
    Response<ProductModel> UpdateProduct(string id, UpdateProduct product);
    Response<ProductModel> DeleteProduct(string id);
}
