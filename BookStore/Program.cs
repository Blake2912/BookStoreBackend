using BookStore.Data;
using BookStore.Repository;
using BookStore.Services;
using BookStore.Util;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database connection
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(
        builder.Configuration.GetConnectionString("localDb")
    ));


// Logging Capabilities
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Depedency Injections
builder.Services
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<IBookService, BookService>()
    .AddScoped<IBookRepository, BookRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IUtil, Util>();

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

