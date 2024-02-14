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
        hotelContext.Categoria.Add(categoria);
        hotelContext.SaveChangesAsync();

    }

    public void DeleteCategoria(Categoria categoria)
    {
        hotelContext.Remove(categoria);
        hotelContext.SaveChangesAsync();

    }

    public Categoria? GetCategoria(int IdCategoria)
    {
        return hotelContext.Categoria.FirstOrDefault(categoria => categoria.IdCategoria == IdCategoria);
    }

    public IEnumerable<Categoria> GetCategorias()
    {
        return hotelContext.Categoria;
    }
}