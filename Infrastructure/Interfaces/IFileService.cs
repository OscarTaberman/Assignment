using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileService
{
    Response<string> SaveProductToFile(string filePath, string productContent);
    Response<string> GetProductFromFile(string filePath);
}
