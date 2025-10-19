namespace Infrastructure.Models;

public class ProductModel
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string ArticleNumber { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

public class CreateProduct
{
    public string Name { get; set; } = null!;
    public string ArticleNumber { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

public class UpdateProduct
{
    public string Name { get; set; } = null!;
    public string ArticleNumber { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}
