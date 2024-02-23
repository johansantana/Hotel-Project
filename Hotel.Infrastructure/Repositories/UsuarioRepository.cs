namespace Hotel.Infrastructure;

public class UsuarioRepository : BaseRepository, IUsuarioRepository
{
    private readonly HotelContext hotelContext;

    public UsuarioRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
    }

    public IEnumerable<Usuario> GetUsuarios()
    {
        try
        {
            return hotelContext.Usuarios;
        }
        catch (Exception)
        {
            throw new UsuarioException();
        }
    }

    public Usuario? GetUsuario(int idUsuario)
    {
        try
        {
            return hotelContext.Usuarios
                .FirstOrDefault(usuario => usuario.IdUsuario == idUsuario);
        }
        catch (Exception)
        {
            throw new UsuarioException();
        }
    }

    public void AddUsuario(Usuario usuario)
    {
        try
        {
            hotelContext.Usuarios.Add(usuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new UsuarioException();
        }
    }

    public void UpdateUsuario(Usuario usuario)
    {
        try
        {
            hotelContext.Usuarios.Update(usuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new UsuarioException();
        }
    }

    public void DeleteUsuario(Usuario usuario)
    {
        try
        {
            hotelContext.Usuarios.Remove(usuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new UsuarioException();
        }
    }
}
