using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    // Cargar aqui los modelos
    public DbSet<Habitacion> Habitaciones { get; set; }
    public DbSet<EstadoHabitacion> EstadoHabitaciones { get; set; }

    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=JOHAN\\SQLEXPRESS;Initial Catalog=DBHotel;Integrated Security=True;User ID=sa;Password=200520; TrustServerCertificate=true;");
    }
}