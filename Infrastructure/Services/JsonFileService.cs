using Infrastructure.Interfaces;
using Infrastructure.Models;
using System.Text.Json;

namespace Infrastructure.Services;

public class JsonFileService : IFileRepository
{
    private readonly string _filePath;

    public JsonFileService(string filePath)
    {
        _filePath = filePath;
    }
    public Response<string> SaveProductToFile<T>(T data)
    {
        try
        {
            var datadirectory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(datadirectory)) 
                Directory.CreateDirectory(datadirectory);

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_filePath, json);

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
        try
        {
            var json = File.ReadAllText(_filePath);

            var productContent = JsonSerializer.Deserialize<string>(json);

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
