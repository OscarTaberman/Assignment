using Infrastructure.Services;
using Infrastructure.Models;
using Infrastructure.Helpers;

namespace Infrastructure.Tests
{
    public class ProductServiceTests
    {
        private ProductService GetServices()
        {
            // Method to generate ProductService instance with GuidGenerator and JsonFileService for testing
            var generator = new GuidGenerator();
            var jsonService = new JsonFileService("test_products.json");

            return new ProductService(generator, jsonService);
        }

        [Fact]
        public void CreateProduct_ShouldAddNewProduct()
        {
            /* Arrange - create an instance from GetServices with Guid and file-service and
            an instance from CreateProduct with Name, ArticleNumber, Description and Price */
            var services = GetServices();
            var testProduct = new CreateProduct
            {
                Name = "TestProduct",
                ArticleNumber = "123",
                Description = "Test",
                Price = 10
            };

            // Act - create a new product with the method
            var result = services.CreateProduct(testProduct);

            // Assert - should return true if successful and not null
            Assert.True(result.Success);
            Assert.NotNull(((Response<ProductModel>)result).Data);

            File.Delete("test_products.json");
        }

        [Fact]
        public void GetProductByName_ShouldReturnProduct()
        {
            /* Arrange - create an instance from GetServices with Guid and save-file and
            an instance from CreateProduct with Name, ArticleNumber, Description and Price, and then creates the product with the method */
            var service = GetServices();
            var testProduct = new CreateProduct
            {
                Name = "FindMe",
                ArticleNumber = "321",
                Description = "Search",
                Price = 50
            };
            service.CreateProduct(testProduct);

            // Act - use the method to find the created product
            var result = service.GetProductByName("FindMe");

            // Assert - should return true if successful, not null and the products name is "FindMe"
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal("FindMe", result.Data.Name);

            File.Delete("test_products.json");
        }

        [Fact]
        public void UpdateProduct_ShouldChangeValues()
        {
            /* Arrange - create an instance from GetServices with and then creates 
            the product with the method CreateProduct with the CreateProduct class as parameter  */
            var service = GetServices();
            service.CreateProduct(new CreateProduct
            {
                Name = "OldName",
                ArticleNumber = "555",
                Description = "Before update",
                Price = 20
            });

            // Act - create an instance from UpdateProduct and using the method to the OldName product with new values
            var update = new UpdateProduct
            {
                Name = "NewName",
                ArticleNumber = "555",
                Description = "After update",
                Price = 25
            };
            var result = service.UpdateProduct("OldName", update);

            // Assert -  should return true if successful, not null and the products name is "NewName"
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal("NewName", result.Data.Name);

            File.Delete("test_products.json");
        }

        [Fact]
        public void DeleteProduct_ShouldRemoveProduct()
        {
            /* Arrange - create an instance from GetServices with and then creates 
            the product with the method CreateProduct with the CreateProduct class as parameter  */
            var service = GetServices();
            service.CreateProduct(new CreateProduct
            {
                Name = "DeleteMe",
                ArticleNumber = "999",
                Description = "To be deleted",
                Price = 5
            });

            // Act - use the method to delete the product
            var result = service.DeleteProduct("DeleteMe");

            // Assert - should return true if successful
            Assert.True(result.Success);

            File.Delete("test_products.json");
        }

        [Fact]
        public void CreateProduct_ShouldFailIfNameAlreadyExists()
        {
            /* Arrange - create an instance from GetServices with Guid and file-service and 
            an instance from CreateProduct with Name, ArticleNumber, Description and Price */
            var service = GetServices();

            var product = new CreateProduct
            {
                Name = "DuplicateProduct",
                ArticleNumber = "111",
                Description = "Test",
                Price = 20
            };

            // Act - use the method to create a product, then use the method to create another product with the same values
            service.CreateProduct(product);
            var result = service.CreateProduct(product);

            // Assert - should return false and Error message from the duplicated product
            Assert.False(result.Success);
            Assert.Equal("The product name already exists", result.Error);

            File.Delete("test_products.json");
        }


        [Fact]
        public void GetProductByName_ShouldReturnErrorIfNotFound()
        {
            // Arrange - create an instance from GetServices with Guid and file-service
            var service = GetServices();

            // Act - use the method with the instance to search for product named 'NonExisting'
            var result = service.GetProductByName("NonExisting");

            // Assert - should return false and Error message if 'NonExisting' is not found
            Assert.False(result.Success);
            Assert.Equal("No product found with: NonExisting", result.Error);
        }


        [Fact]
        public void UpdateProduct_ShouldReturnErrorIfNotFound()
        {
            /* Arrange - create an instance from ProductService with Guid and file-service, 
            use the UpdateProduct class to create an instance */
            var service = GetServices();

            var update = new UpdateProduct
            {
                Name = "DoesNotExist",
                ArticleNumber = "999",
                Description = "No product here",
                Price = 99
            };

            // Act - use the method with the instance to update a non-existing product with the new instance
            var result = service.UpdateProduct("MissingProduct", update);

            // Assert - should return false and Error message if 'MissingProduct' is not found
            Assert.False(result.Success);
            Assert.Equal("No product found with: MissingProduct", result.Error);
        }

        [Fact]
        public void DeleteProduct_ShouldReturnErrorIfNotFound()
        {
            // Arrange - create an instance from GetServices with Guid and file-service
            var service = GetServices();

            // Act - use the method with the instance to search for non-existing product
            var result = service.DeleteProduct("MissingProduct");

            // Assert - should return false and Error message if 'MissingProduct' is not found
            Assert.False(result.Success);
            Assert.Equal("No product found with: MissingProduct", result.Error);
        }
    }
}
