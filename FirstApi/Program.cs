using FirstApi.Context;
using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<Context>
    (options => options
    .UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.MapPost("AddProduct", async (Product product, Context context) =>
{
    context.Product.Add(product);
    await context.SaveChangesAsync();
});

app.MapPost("SelectProduct/{id}", async (int id, Context context) =>
{
    return await context.Product.FirstOrDefaultAsync(p => p.Id == id);
});

app.MapGet("ListProduct", async (Context context) =>
{
    return await context.Product.ToListAsync();
});

app.MapPut("EditProduct", async (int id, Product product, Context context) =>
{
    var productEdit = await context.Product.FirstOrDefaultAsync(p => p.Id == id);

    if (productEdit != null)
    {
        productEdit.Name = product.Name;

        context.Product.Update(productEdit);
        await context.SaveChangesAsync();
    }
});

app.MapDelete("DeleteProduct/{id}", async (int id, Context context) =>
{
    var productDelete = await context.Product.FirstOrDefaultAsync(p => p.Id == id);

    if (productDelete != null)
    {
        context.Product.Remove(productDelete);
        await context.SaveChangesAsync();
    }
});

app.UseSwaggerUI();
app.Run();
