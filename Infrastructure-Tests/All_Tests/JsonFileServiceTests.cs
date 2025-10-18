using Xunit;
using Infrastructure.Services;
using Infrastructure.Models;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Tests
{
    public class JsonFileServiceTests
    {
        private readonly string _testFilePath = "test_products.json";

        [Fact]
        public void SaveProductToFile_ShouldCreateFile()
        {
            // Arrange - create an instance from JsonFileService and a product from ProductModel with Id, Name, Description and Price
            var service = new JsonFileService(_testFilePath);
            var data = new List<ProductModel>
            {
                new() { Id = "1", Name = "Product A", Description = "Test", Price = 10 }
            };

            // Act - use the method to save the product
            var result = service.SaveProductToFile(data);

            // Assert - should return Success and true if the file is saved
            Assert.True(result.Success);
            Assert.True(File.Exists(_testFilePath));


        }

        [Fact]
        public void ReadFromFile_ShouldReturnData()
        {
            // Arrange - create an instance from JsonFileService and a product from ProductModel with Id, Name, Description and Price
            var service = new JsonFileService(_testFilePath);
            var products = new List<ProductModel>
            {
                new ProductModel { Id = "1", Name = "Product A", Description = "Test", Price = 10 }
            };

            // Act - save the product and use the method to read the product in the file
            service.SaveProductToFile(products);

            var result = service.ReadFromFile<List<ProductModel>>();

            // Assert - should return true, content is not null and no duplications
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Single(result.Data);

            File.Delete(_testFilePath);
        }
    }
}
