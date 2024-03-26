using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Service;
using Hotel.Infrastructure.LoggerAdapter;
using Hotel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Hotel.Web.Contracts.Categoria;
using Hotel.Web.Services.Categoria;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoriaServise, CategoriaServices>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
