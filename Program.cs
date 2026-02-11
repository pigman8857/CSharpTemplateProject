using JoiDelivery.Application.Services;
using JoiDelivery.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JoiDbContext>();

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<ProductService>();

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
