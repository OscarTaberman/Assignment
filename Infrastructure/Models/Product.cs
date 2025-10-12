namespace Infrastructure.Models;

public class ProductModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? ArticleNumber { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}

public class CreateProduct
{
    public string Name { get; set; } = null!;
    public string? ArticleNumber { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}

public class UpdateProduct
{
    public string? ArticleNumber { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}

public class Category
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public List<ProductModel> Products { get; set; } = new();
}

public class ProductSupplier
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
