using Hotel.Infrastructure;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly HotelContext hotelContext;

    public CategoriaRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
    }
    public void AddCategoria(Categoria categoria)
    {

        try
        {

            hotelContext.Categorias.Add(categoria);
            hotelContext.SaveChangesAsync();
        }
        catch (System.Exception)
        {

            throw;
        }

    }
    public void UpdateCategoria(Categoria categoria)
    {
        try
        {
            Categoria categoriaUpdated = GetCategoria(categoria.IdCategoria);
            categoriaUpdated.IdCategoria = categoria.IdCategoria;
            categoriaUpdated.Descripcion = categoria.Descripcion;
            categoriaUpdated.Estado = categoria.Estado;
            categoriaUpdated.FechaCreacion = categoria.FechaCreacion;
            hotelContext.Categorias.Update(categoriaUpdated);
            hotelContext.SaveChangesAsync();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public void DeleteCategoria(Categoria categoria)
    {

        try
        {
            Categoria categoriaDeleted = GetCategoria(categoria.IdCategoria);
            hotelContext.Remove(categoriaDeleted);
            hotelContext.SaveChangesAsync();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Categoria? GetCategoria(int IdCategoria)
    {
        return hotelContext.Categorias.FirstOrDefault(categoria => categoria.IdCategoria == IdCategoria);
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return hotelContext.Categorias;
    }
}