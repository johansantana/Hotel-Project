namespace Hotel.Infrastructure;

public class RolUsuarioRepository : BaseRepository, IRolUsuarioRepository
{
    private readonly HotelContext hotelContext;

    public RolUsuarioRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
    }

    public IEnumerable<RolUsuario> GetRolUsuarios()
    {
        return hotelContext.RolUsuarios;
    }

    public RolUsuario? GetRolUsuario(int idRolUsuario)
    {
        return hotelContext.RolUsuarios
            .FirstOrDefault(rolUsuario => rolUsuario.IdRolUsuario == idRolUsuario);
    }

    public void AddRolUsuario(RolUsuario rolUsuario)
    {
        hotelContext.RolUsuarios.Add(rolUsuario);
        hotelContext.SaveChangesAsync();
    }

    public void DeleteRolUsuario(RolUsuario rolUsuario)
    {
        hotelContext.Remove(rolUsuario);
        hotelContext.SaveChangesAsync();
    }
}
