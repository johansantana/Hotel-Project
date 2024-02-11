namespace Hotel.Infrastructure;

public interface IRolUsuarioRepository
{
    IEnumerable<RolUsuario> GetRolUsuarios();
    RolUsuario? GetRolUsuario(int idRolUsuario);
    void AddRolUsuario(RolUsuario rolUsuario);
    void DeleteRolUsuario(RolUsuario rolUsuario);
}
