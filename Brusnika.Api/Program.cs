using Brusnika.Infrastructure;

using Brusnika.Api;
using Brusnika.Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, configuration) =>
{
    configuration.ReadFrom.Configuration(builder.Configuration);
});

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApi()
    .AddApplication();

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(c =>
    {
        c.AllowCredentials();
        c.WithOrigins(
            "https://localhost:8573",
            "http://localhost:8573");
        c.AllowAnyMethod();
        c.AllowAnyHeader();
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(c =>
    {
        c.AllowCredentials();
        c.WithOrigins(
            "https://24procards.ru:8573",
            "http://24procards.ru:8573");
        c.AllowAnyMethod();
        c.AllowAnyHeader();
    });
}

app.MapControllers();

app.Run();
