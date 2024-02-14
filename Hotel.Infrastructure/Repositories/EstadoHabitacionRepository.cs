namespace Hotel.Infrastructure;

public class EstadoHabitacionRepository : BaseRepository, IEstadoHabitacionRepository
{
    private readonly HotelContext hotelContext;

    public EstadoHabitacionRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
    }

    public IEnumerable<EstadoHabitacion> GetEstadoHabitaciones()
    {
        return hotelContext.EstadoHabitaciones;
    }

    public EstadoHabitacion? GetEstadoHabitacion(int idEstadoHabitacion)
    {
        return hotelContext.EstadoHabitaciones
            .FirstOrDefault(estadoHabitacion => estadoHabitacion.IdEstadoHabitacion == idEstadoHabitacion);
    }

    public void AddEstadoHabitacion(EstadoHabitacion estadoHabitacion)
    {
        hotelContext.EstadoHabitaciones.Add(estadoHabitacion);
        hotelContext.SaveChangesAsync();
    }

    public void DeleteEstadoHabitacion(EstadoHabitacion estadoHabitacion)
    {
        hotelContext.EstadoHabitaciones.Remove(estadoHabitacion);
        hotelContext.SaveChangesAsync();
    }
}
