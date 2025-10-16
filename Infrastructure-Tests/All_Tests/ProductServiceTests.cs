using Xunit;
using Infrastructure.Services;
using Infrastructure.Models;
using Infrastructure.Helpers;
using System.IO;

namespace Infrastructure.Tests
{
    public class ProductServiceTests
    {
        private ProductService GetService()
        {
            var guidGen = new GuidGenerator();
            var fileRepo = new JsonFileService("test_products.json");
            return new ProductService(guidGen, fileRepo);
        }

        [Fact]
        public void CreateProduct_ShouldAddNewProduct()
        {
            var service = GetService();
            var product = new CreateProduct
            {
                Name = "TestProduct",
                ArticleNumber = "123",
                Description = "Test",
                Price = 10
            };

            var result = service.CreateProduct(product);

            Assert.True(result.Success);
            Assert.NotNull(((Response<ProductModel>)result).Data);

            File.Delete("test_products.json");
        }

        [Fact]
        public void GetProductByName_ShouldReturnProduct()
        {
            var service = GetService();
            var createProduct = new CreateProduct
            {
                Name = "FindMe",
                ArticleNumber = "321",
                Description = "Search",
                Price = 50
            };
            service.CreateProduct(createProduct);

            var result = service.GetProductByName("FindMe");

            Assert.True(result.Success);
            Assert.Equal("FindMe", result.Data.Name);

            File.Delete("test_products.json");
        }

        [Fact]
        public void UpdateProduct_ShouldChangeValues()
        {
            var service = GetService();
            service.CreateProduct(new CreateProduct
            {
                Name = "OldName",
                ArticleNumber = "555",
                Description = "Before update",
                Price = 20
            });

            var update = new UpdateProduct
            {
                Name = "NewName",
                ArticleNumber = "555",
                Description = "After update",
                Price = 25
            };

            var result = service.UpdateProduct("OldName", update);

            Assert.True(result.Success);
            Assert.Equal("NewName", result.Data.Name);

            File.Delete("test_products.json");
        }

        [Fact]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            var service = GetService();
            service.CreateProduct(new CreateProduct
            {
                Name = "DeleteMe",
                ArticleNumber = "999",
                Description = "To be deleted",
                Price = 5
            });

            var result = service.DeleteProduct("DeleteMe");

            Assert.True(result.Success);

            File.Delete("test_products.json");
        }
    }
}
