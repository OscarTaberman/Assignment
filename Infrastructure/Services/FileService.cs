using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class FileService : IFileRepository
{
    public Response<string> SaveProductToFile<T>(T data)
    {
        try
        {
            return new Response<string>
            {
                Success = true,
                Data = data?.ToString()
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

    public Response<T> ReadFromFile<T>()
    {
        try
        {
            return new Response<T>
            {
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new Response<T>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}
