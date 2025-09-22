
namespace Infrastructure.Models;

public class ProductResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class ProductResult<Type>
{
    public Product? Result { get; set; }
}
