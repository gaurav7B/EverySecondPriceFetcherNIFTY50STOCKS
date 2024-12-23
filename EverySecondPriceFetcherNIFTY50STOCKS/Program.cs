using EverySecondPriceFetcherNIFTY50STOCKS.Controllers.BackGroundService;
using EverySecondPriceFetcherNIFTY50STOCKS.Controllers.StratergicServices;
using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<StockLogger2DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockLoggerDbConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

// Add services for controllers and Swagger UI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure HttpClients
builder.Services.AddHttpClient<StockPriceFetcherService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:6000"); // Base address for StockPriceFetcherService on port 6000
});

builder.Services.AddHttpClient<StockPriceFetcherService2>(client =>
{
    client.BaseAddress = new Uri("https://localhost:6001"); // Base address for StockPriceFetcherService2 on port 6001
});

builder.Services.AddHttpClient<StockPriceFetcherService3>(client =>
{
    client.BaseAddress = new Uri("https://localhost:6002"); // Base address for StockPriceFetcherService2 on port 6001
});

// Register background services
builder.Services.AddHostedService<StockPriceFetcherService>();
builder.Services.AddHostedService<StockPriceFetcherService2>();
builder.Services.AddHostedService<StockPriceFetcherService3>();
builder.Services.AddHostedService<ThreeWhiteSoilders>();

var app = builder.Build();

// Configure middleware for the app
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers to the app
app.MapControllers();

// Run the application
app.Run();
