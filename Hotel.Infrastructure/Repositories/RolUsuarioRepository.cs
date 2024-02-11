namespace Hotel.Infrastructure;

public class RolUsuarioRepository : IRolUsuarioRepository
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

    public RolUsuario? GetRolUsuario(int IdRolUsuario)
    {
        return hotelContext.RolUsuarios
            .FirstOrDefault(rolUsuario => rolUsuario.IdRolUsuario == IdRolUsuario);
    }

    public void AddRolUsuario(RolUsuario RolUsuario)
    {
        hotelContext.RolUsuarios.Add(RolUsuario);
        hotelContext.SaveChangesAsync();
    }

    public void DeleteRolUsuario(RolUsuario RolUsuario)
    {
        hotelContext.Remove(RolUsuario);
        hotelContext.SaveChangesAsync();
    }
}
