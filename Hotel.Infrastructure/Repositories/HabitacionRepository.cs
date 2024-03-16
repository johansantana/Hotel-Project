using Microsoft.Extensions.Logging;

namespace Hotel.Infrastructure;

public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
{
    private readonly HotelContext hotelContext;
    private readonly LoggerAdapter<HabitacionRepository> logger;

    public HabitacionRepository(HotelContext hotelContext, LoggerAdapter<HabitacionRepository> logger) : base(hotelContext)
    {
        this.hotelContext = hotelContext;
        this.logger = logger;
    }

    public override List<Habitacion> GetEntities()
    {
        return base.GetEntities();
    }

    public override List<Habitacion> FindAll(Func<Habitacion, bool> filter)
    {
        return hotelContext.Habitaciones.Where(filter).ToList();
    }

    public override void Add(Habitacion habitacion)
    {
        try
        {
            if (hotelContext.Habitaciones.Any(ha => ha.IdHabitacion == habitacion.IdHabitacion))
            {
                throw new HabitacionException("La habitación se encuentra registrada");
            }
            hotelContext.Habitaciones.Add(habitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new HabitacionException("Error creando la habitación. " + ex.ToString(), logger);
        }
    }

    public override void Update(Habitacion habitacion)
    {
        try
        {
            Habitacion habitacionToUpdate = GetEntity(habitacion.IdHabitacion) ?? throw new HabitacionException("Habitación no encontrada");
            habitacionToUpdate.Numero = habitacion.Numero;
            habitacionToUpdate.Detalle = habitacion.Detalle;
            habitacionToUpdate.Precio = habitacion.Precio;
            habitacionToUpdate.IdEstadoHabitacion = habitacion.IdEstadoHabitacion;
            habitacionToUpdate.IdPiso = habitacion.IdPiso;
            habitacionToUpdate.IdCategoria = habitacion.IdCategoria;
            habitacionToUpdate.Estado = habitacion.Estado;
            hotelContext.Habitaciones.Update(habitacionToUpdate);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new HabitacionException("Error actualizando la habitación. " + ex.ToString(), logger);
        }
    }

    public override void Remove(Habitacion habitacion)
    {
        try
        {
            Habitacion habitacionToDelete = GetEntity(habitacion.IdHabitacion) ?? throw new HabitacionException("Habitación no encontrada");
            hotelContext.Habitaciones.Remove(habitacionToDelete);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new HabitacionException("Error eliminando la habitación. " + ex.ToString(), logger);
        }
    }
}
