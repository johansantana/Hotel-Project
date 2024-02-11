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
        return hotelContext.Usuarios;
    }

    public Usuario? GetUsuario(int IdUsuario)
    {
        return hotelContext.Usuarios
            .FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario);
    }

    public void AddUsuario(Usuario Usuario)
    {
        hotelContext.Usuarios.Add(Usuario);
        hotelContext.SaveChangesAsync();
    }

    public void DeleteUsuario(Usuario Usuario)
    {
        hotelContext.Remove(Usuario);
        hotelContext.SaveChangesAsync();
    }
}
