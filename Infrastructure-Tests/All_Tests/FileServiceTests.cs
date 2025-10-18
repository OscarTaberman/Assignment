using Xunit;
using Infrastructure.Services;

namespace Infrastructure.Tests
{
    public class FileServiceTests
    {
        [Fact]
        public void SaveProductToFile_ShouldReturnSuccessTrue()
        {
            // Arrange - create an instance from FileService class
            var service = new FileService();

            // Act - use the SaveProductToFile method to create a product
            var result = service.SaveProductToFile("Test_product");

            // Assert - the method return Success through Response, and the product is named Test_product
            Assert.True(result.Success);
            Assert.Equal("Test_product", result.Data);
        }

        [Fact]
        public void ReadFromFile_ShouldReturnSuccessTrue()
        {
            // Arrange - create an instance from FileService class
            var service = new FileService();

            // Act - use the ReadFromFile metho to return the content of the file
            var result = service.ReadFromFile<string>();

            // Assert - the method return Success through Response
            Assert.True(result.Success);
        }
    }
}
