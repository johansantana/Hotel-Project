using Hotel.;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión y registro del contexto de la base de datos en la DI
builder.Services.AddDbContext<HotelContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

// Registro de dependencia para el repositorio de categoría
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

// Agregar servicios para controladores
builder.Services.AddControllers();

// Agregar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
