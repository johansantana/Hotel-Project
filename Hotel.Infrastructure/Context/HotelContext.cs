using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    // Cargar aqui los modelos
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
}
