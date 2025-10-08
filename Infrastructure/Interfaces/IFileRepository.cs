using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileRepository
{
    Response<string> SaveProductToFile(string filePath, string productContent);
    Response<string> GetProductFromFile(string filePath);
}
