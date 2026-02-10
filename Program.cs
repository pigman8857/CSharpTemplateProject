using JoiDelivery.Application.Services;
using JoiDelivery.Application.Settings;
using JoiDelivery.Domain.Interfaces;
using JoiDelivery.Infrastructure;
using JoiDelivery.Infrastructure.Repositories;
using JoiDelivery.Presentation.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"#### connectionString >> {connectionString}");
builder.Services.AddDbContext<JoiDbContext>((DbContextOptionsBuilder options) =>
{
    if (builder.Environment.IsDevelopment())
    {
        // Use SQLite for Dev
        options.UseSqlite(connectionString);
        options.EnableSensitiveDataLogging();
    }
    else
    {
        // Use SQL Server or Postgres for Production
        //options.UseSqlServer(connectionString);
    }
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

///Set up configuration objects and use in DI
builder.Services.Configure<ServerSettings>(
    builder.Configuration.GetSection("ServerSettings"));

builder.Services.AddScoped<IUserService, UserService>();
// builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });
}
app.UseHttpsRedirection();

app.MapControllers();
// app.MapControllerRoute(
//     name: "Cart",
//     pattern: "{controller=Cart}/{action=Index}/{id?}");

app.Run();
