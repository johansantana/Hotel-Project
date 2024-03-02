using Hotel.Domain;
using Hotel.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
    }

    public DbSet<Habitacion> Habitaciones { get; set; }
    public DbSet<EstadoHabitacion> EstadoHabitaciones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Recepcion> Recepciones { get; set; } 
    public DbSet<Piso> Pisos { get; set; } 
    public DbSet<Categoria> Categorias { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("Server=LAPTOP-QCIUVPFJ;Database=DBHotel;User ID=sa;Password=Alejandro23@#; TrustServerCertificate=true;");
    // }
}
