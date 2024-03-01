using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    // Cargar aqui los modelos
    public DbSet<Habitacion> Habitaciones { get; set; }
    public DbSet<EstadoHabitacion> EstadoHabitaciones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
}
