namespace Infrastructure.Interfaces;

public interface IFileService
{
    bool SaveProductToFile(string filePath, string productContent);
    string GetProductFromFile(string filePath);
}
