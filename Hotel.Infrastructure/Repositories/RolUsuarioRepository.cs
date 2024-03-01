using Microsoft.Extensions.Logging;

namespace Hotel.Infrastructure;

public class RolUsuarioRepository : BaseRepository<RolUsuario>, IRolUsuarioRepository
{
    private readonly HotelContext hotelContext;
    private readonly ILogger<RolUsuarioRepository> logger;

    public RolUsuarioRepository(HotelContext hotelContext, ILogger<RolUsuarioRepository> logger) : base(hotelContext)
    {
        this.hotelContext = hotelContext;
        this.logger = logger;
    }

    public override List<RolUsuario> GetEntities()
    {
        return base.GetEntities();
    }

    public override List<RolUsuario> FindAll(Func<RolUsuario, bool> filter)
    {
        return hotelContext.RolUsuarios.Where(filter).ToList();
    }

    public override void Add(RolUsuario rolUsuario)
    {
        try
        {
            if (hotelContext.RolUsuarios.Any(ru => ru.IdRolUsuario == rolUsuario.IdRolUsuario))
            {
                throw new RolUsuarioException("El rol de usuario se encuentra registrado");
            }
            hotelContext.RolUsuarios.Add(rolUsuario);
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Error creando el rol de usuario: {}", ex.ToString());
        }
    }

    public override void Update(RolUsuario rolUsuario)
    {
        try
        {
            RolUsuario rolUsuarioUpdated = GetEntity(rolUsuario.IdRolUsuario) ?? throw new RolUsuarioException("Rol de Usuario no encontrado");
            rolUsuarioUpdated.Descripcion = rolUsuario.Descripcion;
            rolUsuarioUpdated.Estado = rolUsuario.Estado;
            hotelContext.RolUsuarios.Update(rolUsuarioUpdated);
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Error actualizando el rol de usuario: {}", ex.ToString());
        }
    }

    public override void Remove(RolUsuario rolUsuario)
    {
        try
        {
            RolUsuario rolUsuarioDeleted = GetEntity(rolUsuario.IdRolUsuario) ?? throw new UsuarioException("Rol de Usuario no encontrado");
            hotelContext.RolUsuarios.Remove(rolUsuarioDeleted);
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Error eliminando el rol de usuario: {}", ex.ToString());
        }
    }
}
