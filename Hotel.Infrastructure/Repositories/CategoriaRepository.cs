using Hotel.Infrastructure;
using Microsoft.Extensions.Logging;

public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
{
    private readonly HotelContext hotelContext;
    private readonly ILogger<CategoriaRepository> logger;
    //Realizar abstraccion de esta interfaz 

    public CategoriaRepository(HotelContext hotelContext, ILogger<CategoriaRepository> logger) : base(hotelContext)
    {
        this.hotelContext = hotelContext;
        this.logger = logger;
    }
    public override List<Categoria> GetEntities()
    {
        return base.GetEntities();

    }

    public override List<Categoria> FindAll(Func<Categoria, bool> filter)
    {
        return hotelContext.Categorias.Where(filter).ToList();

    }
    public override void Update(Categoria categoria)
    {
        try
        {
            Categoria categoriaUpdated = GetEntity(categoria.IdCategoria);

            categoriaUpdated.IdCategoria = categoria.IdCategoria;
            categoriaUpdated.Descripcion = categoria.Descripcion;
            categoriaUpdated.Estado = categoria.Estado;
            categoriaUpdated.FechaCreacion = categoria.FechaCreacion;
            hotelContext.Categorias.Update(categoriaUpdated);

            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error actualizando la categoria", ex.ToString());
        }

    }
    public override void Add(Categoria categoria)
    {
        try
        {
            hotelContext.Categorias.Add(categoria);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error Creando la categoria", ex.ToString());
        }
    }
    public override void Remove(Categoria categoria)
    {
        try
        {
            Categoria categoriaDeleted = GetEntity(categoria.IdCategoria);
            hotelContext.Remove(categoriaDeleted);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error eliminando la categoria", ex.ToString());
        }
    }

}