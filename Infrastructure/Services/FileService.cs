using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public bool SaveProductToFile(string filePath, string productContent)
    {
        try
        {
            return new bool { };
        }
        catch (Exception ex)
        {
            return new bool {  };
        }
    }

    public string GetProductFromFile(string filePath)
    {
        throw new NotImplementedException();
    }
}
