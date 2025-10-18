using Infrastructure.Helpers;

namespace Infrastructure.Tests
{
    public class GuidGeneratorTests
    {
        [Fact]
        public void GenerateGuid_ShouldReturnUniqueString()
        {
            // Arrange - create an instance from GuidGenerator class
            var generator = new GuidGenerator();

            // Act - use the GenerateGuid method to generate two seperate IDs
            var id1 = generator.GenerateGuid();
            var id2 = generator.GenerateGuid();

            // Assert - verify that the ID is not null and that is not the same as the other
            Assert.NotNull(id1);
            Assert.NotEqual(id1, id2);
        }
    }
}