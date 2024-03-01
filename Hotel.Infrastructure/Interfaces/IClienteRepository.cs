namespace Hotel.Infrastructure;

public interface IUsuarioRepository
{
    IEnumerable<Cliente> GetClientes();
    Cliente? GetCliente(int IdCliente);
    void AddCliente(Cliente Cliente);
    void DeleteCliente(Cliente Cliente);
}
