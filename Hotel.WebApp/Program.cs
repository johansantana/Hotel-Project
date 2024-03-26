using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Service;
using Hotel.Infrastructure.LoggerAdapter;
using Hotel.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container. agregar registro de dependencia
// String connection
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

//Repositories
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//Illoggers
builder.Services.AddSingleton<ILoggerAdapter<CategoriaService>, LoggerAdapter<CategoriaService>>();
builder.Services.AddSingleton<ILoggerAdapter<CategoriaRepository>, LoggerAdapter<CategoriaRepository>>();

//App Services
builder.Services.AddTransient<ICategoriaService, CategoriaService>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
