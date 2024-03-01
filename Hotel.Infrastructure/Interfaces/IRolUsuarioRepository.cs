namespace Hotel.Infrastructure;

public interface IRolUsuarioRepository
{
    IEnumerable<RolUsuario> GetRolUsuarios();
    RolUsuario? GetRolUsuario(int IdRolUsuario);
    void AddRolUsuario(RolUsuario RolUsuario);
    void DeleteRolUsuario(RolUsuario RolUsuario);
}
