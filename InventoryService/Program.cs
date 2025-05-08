using InventoryService.Service;
using MassTransit;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProductService>(new ProductService("./Data.json"));
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<IHealthCheckHandler, ScopedEurekaHealthCheckHandler>();
builder.Services.AddDiscoveryClient(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDiscoveryClient();
app.UseHealthChecks("/info");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
