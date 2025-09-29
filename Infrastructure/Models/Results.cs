namespace Infrastructure.Models;

public class Results
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class Results<T> : Results
{
    public T? Data { get; set; }
}
