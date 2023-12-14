using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TechTestVPEF.Data;
using TechTestVPEF.Data.Repositories.Interfaces;
using TechTestVPEF.Data.Repositories.Order;
using TechTestVPEF.Data.Repositories.Product;
using TechTestVPEF.Engine.Interfaces;
using TechTestVPEF.Engine.Services.Order;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration _config = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory()).
AddJsonFile("appSettings.json", false)
.Build();

builder.Services.AddDbContext<TechTestVpContext>(
        options => options.UseSqlServer(_config.GetConnectionString("DB")));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();