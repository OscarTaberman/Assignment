using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

string filePath = @"c:\data\products.json";

var builder = Host.CreateApplicationBuilder();
builder.Services.AddSingleton<IFileService>(_ => new JsonFileService(filePath));

