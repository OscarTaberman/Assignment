using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    ProductResults<string> SaveProductToFile(string filePath, string productContent);
    ProductResults<string> GetProductFromFile(string filePath);
}
