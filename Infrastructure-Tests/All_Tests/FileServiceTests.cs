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

            // Act - use the SaveProductToFile method to create a 
            var result = service.SaveProductToFile("Test_product");

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Test_product", result.Data);
        }

        [Fact]
        public void ReadFromFile_ShouldReturnSuccessTrue()
        {
            var service = new FileService();
            var result = service.ReadFromFile<string>();

            Assert.True(result.Success);
        }
    }
}
