namespace Hotel.Infrastructure;
using Microsoft.Extensions.Logging;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    private readonly HotelContext hotelContext;
    private readonly ILogger<UsuarioRepository> logger;

    public UsuarioRepository(HotelContext hotelContext, ILogger<UsuarioRepository> logger) : base(hotelContext)
    {
        this.hotelContext = hotelContext;
        this.logger = logger;
    }

    public override List<Usuario> GetEntities()
    {
        return base.GetEntities();
    }

    public override List<Usuario> FindAll(Func<Usuario, bool> filter)
    {
        return hotelContext.Usuarios.Where(filter).ToList();
    }

    public override void Add(Usuario usuario)
    {
        try
        {
            if (hotelContext.Usuarios.Any(us => us.IdUsuario == usuario.IdUsuario))
            {
                throw new UsuarioException("El usuario se encuentra registrado");
            }
            hotelContext.Usuarios.Add(usuario);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error creando el usuario: {}", ex.ToString());
        }
    }

    public override void Update(Usuario usuario)
    {
        try
        {
            Usuario usuarioUpdated = GetEntity(usuario.IdUsuario) ?? throw new UsuarioException("Usuario no encontrado");
            usuarioUpdated.Clave = usuario.Clave;
            usuarioUpdated.Correo = usuario.Correo;
            usuarioUpdated.NombreCompleto = usuario.NombreCompleto;
            usuarioUpdated.Estado = usuario.Estado;
            usuarioUpdated.IdRolUsuario = usuario.IdRolUsuario;
            hotelContext.Usuarios.Update(usuarioUpdated);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error actualizando el usuario: {}", ex.ToString());
        }
    }

    public override void Remove(Usuario usuario)
    {
        try
        {
            Usuario usuarioDeleted = GetEntity(usuario.IdUsuario) ?? throw new UsuarioException("Usuario no encontrado");
            hotelContext.Usuarios.Remove(usuarioDeleted);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error eliminando el usuario: {}", ex.ToString());
        }
    }
}
