using RecipeCostControl.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder
    .AddDatabaseComponents()
    .AddRepositories()
    .AddServices()
    .AddAutoMapper();

var app = builder.BuildConfiguredApplication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();