namespace Hotel.Infrastructure;

public interface IUsuarioRepository
{
    IEnumerable<Usuario> GetUsuarios();
    Usuario? GetUsuario(int IdUsuario);
    void AddUsuario(Usuario Usuario);
    void DeleteUsuario(Usuario Usuario);
}
