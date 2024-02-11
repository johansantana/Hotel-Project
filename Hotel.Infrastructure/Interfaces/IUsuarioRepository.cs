namespace Hotel.Infrastructure;

public interface IUsuarioRepository
{
    IEnumerable<Usuario> GetUsuarios();
    Usuario? GetUsuario(int idUsuario);
    void AddUsuario(Usuario usuario);
    void DeleteUsuario(Usuario usuario);
}
