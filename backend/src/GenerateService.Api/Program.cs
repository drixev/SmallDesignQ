using GenerateService.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApi();
builder.Services.AddApplication();

// build

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
