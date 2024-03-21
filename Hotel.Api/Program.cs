using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Service;
using Hotel.Infrastructure;
using Hotel.Infrastructure.LoggerAdapter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
