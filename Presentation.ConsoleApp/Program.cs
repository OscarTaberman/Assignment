using Infrastructure.Helpers;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string filePath = @"c:\data\products.json";

var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IFileRepository>(sp => new JsonFileService(filePath));
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IGuidGenerator, GuidGenerator>();
builder.Services.AddSingleton<MenuService>();


var program = builder.Build();