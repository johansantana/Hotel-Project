using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    // Cargar aqui los modelos
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Piso> pisos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Hotel_DB");
    }
}
