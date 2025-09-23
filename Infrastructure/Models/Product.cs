namespace Infrastructure.Models;

public class BaseProduct
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? ArticleNumber { get; set; }
    public bool IsService { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}

public class CreateProduct
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}

public class Category
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public List<BaseProduct> Products { get; set; } = new();
}

public class ProductSupplier
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
