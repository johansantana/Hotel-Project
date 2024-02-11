using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure;

public class HotelContext : DbContext
{
    // Cargar aqui los modelos

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Hotel_DB");
    }
}
