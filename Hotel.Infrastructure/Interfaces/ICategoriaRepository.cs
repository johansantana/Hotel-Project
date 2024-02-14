public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategorias();
    Categoria? GetCategoria(int IdCategoria);
    void AddCategoria(Categoria categoria);

    void DeleteCategoria(Categoria categoria);
}