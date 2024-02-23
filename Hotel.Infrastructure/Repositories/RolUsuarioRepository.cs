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
        try
        {
            return hotelContext.RolUsuarios;
        }
        catch (Exception)
        {
            throw new RolUsuarioException();
        }
    }

    public RolUsuario? GetRolUsuario(int idRolUsuario)
    {
        try
        {
            return hotelContext.RolUsuarios
                .FirstOrDefault(rolUsuario => rolUsuario.IdRolUsuario == idRolUsuario);
        }
        catch (Exception)
        {
            throw new RolUsuarioException();
        }
    }

    public void AddRolUsuario(RolUsuario rolUsuario)
    {
        try
        {
            hotelContext.RolUsuarios.Add(rolUsuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new RolUsuarioException();
        }
    }

    public void UpdateRolUsuario(RolUsuario rolUsuario)
    {
        try
        {
            hotelContext.RolUsuarios.Update(rolUsuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new RolUsuarioException();
        }
    }

    public void DeleteRolUsuario(RolUsuario rolUsuario)
    {
        try
        {
            hotelContext.RolUsuarios.Remove(rolUsuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new RolUsuarioException();
        }
    }
}
