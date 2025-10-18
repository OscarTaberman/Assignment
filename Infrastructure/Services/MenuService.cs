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
            Console.WriteLine("6. Delete Product");
            Console.WriteLine();
            Console.WriteLine("0. Exit application");
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

                case "0":
                    return;

                default:
                    Console.Clear();
                    break;
            }

        }

    }


    private void CreateProduct()
    {
        Console.WriteLine("Enter a product name: ");
        var name = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid input. Please try again.");
        }

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

        var newProduct = new CreateProduct()
        {
            Name = name,
            ArticleNumber = articlenumber,
            Description = description,
            Price = price,
        };

        var result = _productService.CreateProduct(newProduct);
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
                Console.WriteLine($"Id:     {product.Id}");
                Console.WriteLine($"Name:   {product.Name}");
                Console.WriteLine($"Price:  {product.Price} kr");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Failed to read products.");
            if (!string.IsNullOrWhiteSpace(response.Error))
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
            if (!string.IsNullOrWhiteSpace(response.Error))
                Console.WriteLine($"Error: {response.Error}");
        }

        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void GetProductByArticleNumber()
    {
        Console.WriteLine("Enter existing product's article number: ");
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
            if (!string.IsNullOrWhiteSpace(response.Error))
                Console.WriteLine($"Error: {response.Error}");
        }

        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void UpdateProduct()
    {
        Console.WriteLine("Enter existing product's name: ");
        var findName = Console.ReadLine();

        var response = _productService.GetProductByName(findName!);
        if (response.Success && response.Data != null)
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

            var updatedProduct = new UpdateProduct
            {
                Name = name,
                ArticleNumber = articlenumber,
                Description = description,
                Price = price,
            };

            var result = _productService.UpdateProduct(findName!, updatedProduct);
            if (result.Success)
                Console.WriteLine("Product updated successfully.");
            else
                Console.WriteLine("Failed to update product.");
        }

        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    private void DeleteProduct()
    {
        Console.WriteLine("Enter existing product's name: ");
        var findName = Console.ReadLine();

        var response = _productService.GetProductByName(findName!);
        if (response.Success && response.Data != null)
        {
            Console.WriteLine($"Do you want to delete {findName}? y/n: ");
            var delete = Console.ReadLine();

            switch (delete)
            {
                case "y":
                    var yes = _productService.DeleteProduct(findName!);

                    break;

                case "n":
                    break;
            }
        }
        Console.WriteLine("_____________________________");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public void Run()
    {
        MainMenu();
    }
}
