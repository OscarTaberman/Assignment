namespace Infrastructure.Models;

public class ProductResults<T> where T : class
{
    public bool Success { get; set; }
    public string Error { get; set; } = null!;
}
