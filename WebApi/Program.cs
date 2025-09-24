using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Infrastructure") 
    ));


// Repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// MediatR
builder.Services.AddMediatR(typeof(Application.Features.Products.Queries.GetAllProductsQuery).Assembly);

builder.Services.AddControllers();

//   Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My Clean Architecture API",
        Version = "v1",
        Description = "A simple ASP.NET Core Web API with Clean Architecture + CQRS + MediatR"
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
