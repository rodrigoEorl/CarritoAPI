using Carrito.Api.Middleware;
using Carrito.Application.Interfaces;
using Carrito.Application.Services;
using Carrito.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application
builder.Services.AddScoped<CarritoService>();

// Infrastructure
builder.Services.AddSingleton<IRepositorioProductos, RepositorioProductosEnMemoria>();
builder.Services.AddSingleton<IRepositorioCarrito, RepositorioCarritoEnMemoria>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
