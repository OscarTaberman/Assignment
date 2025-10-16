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
            var service = new JsonFileService(_testFilePath);
            var data = new List<ProductModel>
            {
                new ProductModel { Id = "1", Name = "Product A", Description = "Test", Price = 10 }
            };

            var result = service.SaveProductToFile(data);

            Assert.True(result.Success);
            Assert.True(File.Exists(_testFilePath));

            File.Delete(_testFilePath);
        }

        [Fact]
        public void ReadFromFile_ShouldReturnData()
        {
            // Arange
            var service = new JsonFileService(_testFilePath);
            var products = new List<ProductModel>
            {
                new ProductModel { Id = "1", Name = "Product A", Description = "Test", Price = 10 }
            };

            // Act 
            service.SaveProductToFile(products);

            var result = service.ReadFromFile<List<ProductModel>>();

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Single(result.Data);

            File.Delete(_testFilePath);
        }
    }
}
