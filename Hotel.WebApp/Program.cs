using Hotel.Application.Contracts;
using Hotel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Hotel.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connections.
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

// Repositories.
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolUsuarioRepository, RolUsuarioRepository>();

// Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRolUsuarioService, RolUsuarioService>();

// Logger
builder.Services.AddScoped(typeof(LoggerAdapter<>));

// App Services.
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
