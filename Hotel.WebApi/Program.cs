using Hotel.Application.Contracts;
using Hotel.Application.Services;
using Hotel.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connections.
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

// Repositories.
builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();
builder.Services.AddScoped<IEstadoHabitacionRepository, EstadoHabitacionRepository>();

// Services.
builder.Services.AddScoped<IHabitacionService, HabitacionService>();
builder.Services.AddScoped<IEstadoHabitacionService, EstadoHabitacionService>();

// Logger
builder.Services.AddScoped(typeof(LoggerAdapter<>));

// App Services.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();