using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IFileRepository
{
    Response<string> SaveProductToFile<T>(T data);
    Response<T> ReadFromFile<T>();
}
