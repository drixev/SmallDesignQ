using GenerateService.Api.Extensions;
using GenerateService.Application;
using GenerateService.Infraestructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfraestructure();

// build

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors((opt) =>
{
    opt.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
