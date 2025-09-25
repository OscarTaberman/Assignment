using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public ProductResults<string> SaveProductToFile(string filePath, string productContent)
    {
        try
        {
            return new ProductResults<string>
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ProductResults<string>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public ProductResults<string> GetProductFromFile(string filePath)
    {
        try
        {
            return new ProductResults<string>
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ProductResults<string>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}
