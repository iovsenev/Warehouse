using Microsoft.OpenApi.Models;
using Warehouse.Api;
using Warehouse.Application;
using Warehouse.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(config);
builder.Services.AddApplication();
builder.Services.AddScoped<AdminAdder>();

builder.Services.AddAppIdentity(config);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Warehouse API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
}
using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider.GetRequiredService<AdminAdder>();
await service.AddAdmin();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
