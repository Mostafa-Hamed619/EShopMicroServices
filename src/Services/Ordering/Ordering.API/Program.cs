using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrasturcutrServices(builder.Configuration)
    .AddApiSerivces();

var app = builder.Build();


app.Run();
