using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    // Cargar aqui los modelos
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Piso> Pisos { get; set; }

    public DbSet<Categoria> Categoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Hotel_DB");
    }
}
