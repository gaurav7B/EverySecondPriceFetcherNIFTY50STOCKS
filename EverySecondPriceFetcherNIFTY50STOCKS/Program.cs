using EverySecondPriceFetcherNIFTY50STOCKS.Model;
using Microsoft.EntityFrameworkCore;
using StockLogger.BackgroundServices.BackGroundServiceForEach;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StockLogger2DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockLoggerDbConnection"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient
builder.Services.AddHttpClient(); // This adds the HttpClient service

builder.Services.AddHostedService<MadMaxService>();
builder.Services.AddHostedService<_2Service>();
builder.Services.AddHostedService<_3Service>();
builder.Services.AddHostedService<_4Service>();
builder.Services.AddHostedService<_5Service>();

builder.Services.AddHostedService<_6Service>();
builder.Services.AddHostedService<_7Service>();
builder.Services.AddHostedService<_8Service>();
builder.Services.AddHostedService<_9Service>();
builder.Services.AddHostedService<_10Service>();

//builder.Services.AddHostedService<_11Service>();
//builder.Services.AddHostedService<_12Service>();
//builder.Services.AddHostedService<_13Service>();
//builder.Services.AddHostedService<_14Service>();
//builder.Services.AddHostedService<_15Service>();

//builder.Services.AddHostedService<_16Service>();
//builder.Services.AddHostedService<_17Service>();
//builder.Services.AddHostedService<_18Service>();
//builder.Services.AddHostedService<_19Service>();
//builder.Services.AddHostedService<_20Service>();

//builder.Services.AddHostedService<_21Service>();
//builder.Services.AddHostedService<_22Service>();
//builder.Services.AddHostedService<_23Service>();
//builder.Services.AddHostedService<_24Service>();
//builder.Services.AddHostedService<_25Service>();

//builder.Services.AddHostedService<_26Service>();
//builder.Services.AddHostedService<_27Service>();
//builder.Services.AddHostedService<_28Service>();
//builder.Services.AddHostedService<_29Service>();
//builder.Services.AddHostedService<_30Service>();

//builder.Services.AddHostedService<_31Service>();
//builder.Services.AddHostedService<_32Service>();
//builder.Services.AddHostedService<_33Service>();
//builder.Services.AddHostedService<_34Service>();
//builder.Services.AddHostedService<_35Service>();

//builder.Services.AddHostedService<_36Service>();
//builder.Services.AddHostedService<_37Service>();
//builder.Services.AddHostedService<_38Service>();
//builder.Services.AddHostedService<_39Service>();
//builder.Services.AddHostedService<_40Service>();

//builder.Services.AddHostedService<_41Service>();
//builder.Services.AddHostedService<_42Service>();
//builder.Services.AddHostedService<_43Service>();
//builder.Services.AddHostedService<_44Service>();
//builder.Services.AddHostedService<_45Service>();

//builder.Services.AddHostedService<_46Service>();
//builder.Services.AddHostedService<_47Service>();
//builder.Services.AddHostedService<_48Service>();
//builder.Services.AddHostedService<_49Service>();
//builder.Services.AddHostedService<_50Service>();


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
