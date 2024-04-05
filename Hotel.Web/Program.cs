using Hotel.Infrastructure;
using Hotel.Web.Services.EstadoHabitacion;
using Hotel.Web.Services.Habitacion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHabitacionService, HabitacionService>();
builder.Services.AddScoped<IEstadoHabitacionService, EstadoHabitacionService>();

// Logger
builder.Services.AddScoped(typeof(LoggerAdapter<>));

// Http Client
builder.Services.AddHttpClient("api", options =>
{
    options.BaseAddress = new Uri("http://localhost:5202");
});


// Add services to the container.
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
