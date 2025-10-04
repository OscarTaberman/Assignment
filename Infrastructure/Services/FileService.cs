using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public Response<string> SaveProductToFile(string filePath, string productContent)
    {
        try
        {
            return new Response<string>
            {
                Success = true,
                Data = productContent
            };
        }
        catch (Exception ex)
        {
            return new Response<string>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public Response<string> GetProductFromFile(string filePath)
    {
        try
        {
            return new Response<string>
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new Response<string>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}
