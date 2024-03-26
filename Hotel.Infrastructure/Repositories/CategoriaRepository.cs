using Hotel.Infrastructure;
using Hotel.Domain;
using Hotel.Infrastructure.LoggerAdapter;
public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
{
    private readonly HotelContext hotelContext;
    //  private readonly LoggerAdapter<CategoriaRepository> logger; // loger es el adaptador, el cliente es Categoria repository y el targer es CategoriaException
    //Realizar abstraccion de esta interfaz 
    private readonly ILoggerAdapter<CategoriaRepository> logger;
    public CategoriaRepository(HotelContext hotelContext, ILoggerAdapter<CategoriaRepository> logger ) : base(hotelContext)
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
        List<Categoria> listDeCategorias;
        try { 

          listDeCategorias = hotelContext.Categoria.Where(filter).ToList();
          return listDeCategorias;
        }
        catch (Exception ex){
            
          throw new CategoriaException("Error obteniendo las categorias" + ex.ToString(), logger);
        }
        
    }
    public override void Update(Categoria categoria)
    {
        try
        {
            Categoria categoriaUpdated = GetEntity(categoria.IdCategoria);

            if (categoriaUpdated is null)
            {
               throw new CategoriaException("la categoria no existe", logger);
            }
                

            categoriaUpdated.Descripcion = categoria.Descripcion;
            categoriaUpdated.Estado = categoria.Estado;
            hotelContext.Categoria.Update(categoriaUpdated);

            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
           // _logger.LogError("Error actualizando la categoria" + ex.ToString());
           throw new CategoriaException("Error actualizando la categoria" + ex.ToString(), logger);
            
           
        }

    }
    public override void Add(Categoria categoria)
    {
        try
        {
            if (hotelContext.Categoria.Any(ca => ca.IdCategoria == categoria.IdCategoria))
            {
              throw new CategoriaException("La categoria se encuentra registrada", logger);
            }

            hotelContext.Categoria.Add(categoria);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            //_logger.LogError("Error Creando la categoria" + ex.ToString());
           throw  new CategoriaException("La categoria se encuentra registrada" + ex.ToString(), logger);
        }
    }
    public override void Remove(Categoria categoria)
    {
        try
        {
            Categoria categoriaDeleted = GetEntity(categoria.IdCategoria);

            if (categoriaDeleted is null)
            {
              throw new CategoriaException("la categoria no existe", logger);
            }
                 
            
            hotelContext.Categoria.Remove(categoriaDeleted);
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            //_logger.LogError("Error eliminando la categoria" );
            throw new CategoriaException("la categoria no existe"+ ex.ToString(), logger);
        }
    }

}