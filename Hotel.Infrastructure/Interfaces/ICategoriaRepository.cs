public interface ICategoriaRepository
{
    IEnumerable<Categoria> GetCategorias();
    Categoria? GetCategoria(int IdCategoria);
    void addCategoria(Categoria categoria);

    void deleteCategoria(Categoria categoria);
}