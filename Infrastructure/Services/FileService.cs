using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public Results<string> SaveProductToFile(string filePath, string productContent)
    {
        try
        {
            return new Results<string>
            {
                Success = true,
                Data = productContent
            };
        }
        catch (Exception ex)
        {
            return new Results<string>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public Results<string> GetProductFromFile(string filePath)
    {
        try
        {
            return new Results<string>
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new Results<string>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}
