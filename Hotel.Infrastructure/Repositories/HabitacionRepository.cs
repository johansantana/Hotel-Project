using Microsoft.Extensions.Logging;

namespace Hotel.Infrastructure;

public class HabitacionRepository : BaseRepository<Habitacion>, IHabitacionRepository
{
    private readonly HotelContext hotelContext;
    private readonly ILogger<HabitacionRepository> logger;

    public HabitacionRepository(HotelContext hotelContext, ILogger<HabitacionRepository> logger) : base(hotelContext)
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
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Error creando la habitación: {}", ex.ToString());
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
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Error actualizando el rol de usuario: {}", ex.ToString());
        }
    }

    public override void Remove(Habitacion habitacion)
    {
        try
        {
            Habitacion habitacionToDelete = GetEntity(habitacion.IdHabitacion) ?? throw new HabitacionException("Habitación no encontrada");
            hotelContext.Habitaciones.Remove(habitacionToDelete);
            hotelContext.SaveChanges();
        }
        catch (Exception ex)
        {
            logger.LogError("Error eliminando la habitación: {}", ex.ToString());
        }
    }
}
