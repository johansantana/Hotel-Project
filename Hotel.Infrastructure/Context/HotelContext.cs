using Microsoft.EntityFrameworkCore;
using Hotel.Domain;
namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
        
    }
    // Cargar aqui los modelos
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Categoria> Categoria { get; set; }
    

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
      //  optionsBuilder.UseSqlServer("Server=LAPTOP-QCIUVPFJ;Database=DBHotel;User ID=sa;Password=Alejandro23@#; TrustServerCertificate=true;");
    //}
}
