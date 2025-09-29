using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    Results<string> SaveProductToFile(string filePath, string productContent);
    Results<string> GetProductFromFile(string filePath);
}
