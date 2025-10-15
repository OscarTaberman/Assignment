using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class MenuService(IProductService productService)
{
    private readonly IProductService _productService = productService;

    private void MainMenu()
    {
        while (true)
        {


            Console.WriteLine("----  MENU OPTIONS  ----");
            Console.WriteLine();
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine();
            Console.WriteLine("3. Find Product By Name");
            Console.WriteLine("4. Find Product By Article Number");
            Console.WriteLine();
            Console.WriteLine("5. Update Product");
            Console.WriteLine("6. Remove Product");
            Console.WriteLine("_________________");
            Console.Write("Choose an option: ");
            var options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    Console.Clear();
                    CreateProduct();
                    break;

                case "2":
                    Console.Clear();
                    ReadAllProducts();
                    break;

                case "3":
                    Console.Clear();
                    GetProductByName();
                    break;

                case "4":
                    Console.Clear();
                    GetProductByArticleNumber();
                    break;

                case "5":
                    Console.Clear();
                    UpdateProduct();
                    break;

                case "6":
                    Console.Clear();
                    DeleteProduct();
                    break;
            }

        }

    }

    private void CreateProduct()
    {
        Console.WriteLine("Enter a product name: ");
        var name = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine("Enter an article number: ");
        var articlenumber = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter a product description: ");
        var description = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine("Enter a product price: ");
        var price = decimal.Parse(Console.ReadLine()!);
        Console.WriteLine();

        var product = new CreateProduct()
        {
            Name = name,
            ArticleNumber = articlenumber,
            Description = description,
            Price = price,
        };

        var result = _productService.CreateProduct(product);
        if (result.Success)
            Console.WriteLine("Product created successfully.");
        else
            Console.WriteLine("Failed to create product.");

        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void ReadAllProducts()
    {
        var productModel = new ProductModel();

        var response = _productService.ReadAllProducts(productModel);
        if (response.Success && response.Data != null)
        {
            foreach (var product in response.Data)
            {
                Console.WriteLine(product.Name);
            }
        }
        else
        {
            Console.WriteLine("Failed to read products.");
            if (!string.IsNullOrEmpty(response.Error))
                Console.WriteLine($"Error: {response.Error}");
        }
        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetProductByName()
    {
        Console.WriteLine("Enter existing product's name: ");
        var findName = Console.ReadLine();

        var response = _productService.GetProductByName(findName!);
        if (response.Success && response.Data != null)
        {
            Console.WriteLine();
            var product = response.Data;
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Article Number: {product.ArticleNumber}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price} kr");
        }
        else
        {
            Console.WriteLine("Failed to find the product.");
            if (!string.IsNullOrEmpty(response.Error))
                Console.WriteLine($"Error: {response.Error}");
        }

        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetProductByArticleNumber()
    {
        Console.WriteLine("Enter existing product's name: ");
        var findArticleNumber = Console.ReadLine();

        var response = _productService.GetProductByArticleNumber(findArticleNumber!);
        if (response.Success && response.Data != null)
        {
            Console.WriteLine();
            var product = response.Data;
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Article Number: {product.ArticleNumber}");
            Console.WriteLine($"Description: {product.Description}");
            Console.WriteLine($"Price: {product.Price} kr");
        }
        else
        {
            Console.WriteLine("Failed to find the product.");
            if (!string.IsNullOrEmpty(response.Error))
                Console.WriteLine($"Error: {response.Error}");
        }

        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    private void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        MainMenu();
    }
}
