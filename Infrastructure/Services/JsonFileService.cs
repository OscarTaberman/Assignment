using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class JsonFileService : IFileRepository
{
    private readonly string _filePath;

    public JsonFileService(string filePath)
    {
        _filePath = filePath;
    }
    public Response<string> SaveProductToFile(string filePath, string productContent)
    {
        try
        {
            var datadirectory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(datadirectory)) 
                Directory.CreateDirectory(datadirectory);

            File.WriteAllText(_filePath, productContent);

            return new Response<string>
                {
                    Success = true,
                    Data = $"Product was successfully saved to: {_filePath}"
                };

        }
        catch (Exception ex)
        {
            return new Response<string>
            {
                Success = false,
                Error = $"Failed to save product: {ex.Message}"
            };
        }
    }
    public Response<string> ReadFromFile(string filePath)
    {
        var productContent = File.ReadAllText(_filePath);
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
                Error = $"Failed to read product: {ex.Message}"
            };
        }
    }
}
