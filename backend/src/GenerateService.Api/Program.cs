using GenerateService.Api.Extensions;
using GenerateService.Application;
using GenerateService.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfraestructure();

// build

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
