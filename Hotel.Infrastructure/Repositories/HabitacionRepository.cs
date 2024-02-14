namespace Hotel.Infrastructure;

public class HabitacionRepository : BaseRepository, IHabitacionRepository
{
    private readonly HotelContext hotelContext;

    public HabitacionRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
    }

    public IEnumerable<Habitacion> GetHabitaciones()
    {
        return hotelContext.Habitaciones;
    }

    public Habitacion? GetHabitacion(int idHabitacion)
    {
        return hotelContext.Habitaciones
            .FirstOrDefault(habitacion => habitacion.IdHabitacion == idHabitacion);
    }

    public void AddHabitacion(Habitacion habitacion)
    {
        hotelContext.Habitaciones.Add(habitacion);
        hotelContext.SaveChangesAsync();
    }

    public void DeleteHabitacion(Habitacion habitacion)
    {
        hotelContext.Habitaciones.Remove(habitacion);
        hotelContext.SaveChangesAsync();
    }
}
