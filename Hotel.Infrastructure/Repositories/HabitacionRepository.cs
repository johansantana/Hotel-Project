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
        try
        {
            return hotelContext.Habitaciones;
        }
        catch (HabitacionException)
        {
            throw new HabitacionException();
        }
    }

    public Habitacion? GetHabitacion(int idHabitacion)
    {
        try
        {
            return hotelContext.Habitaciones
                .FirstOrDefault(habitacion => habitacion.IdHabitacion == idHabitacion);
        }
        catch (HabitacionException)
        {
            throw new HabitacionException();
        }

    }

    public void AddHabitacion(Habitacion habitacion)
    {
        try
        {
            hotelContext.Habitaciones.Add(habitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (HabitacionException)
        {
            throw new HabitacionException();
        }
    }

    public void UpdateHabitacion(Habitacion habitacion)
    {
        try
        {
            hotelContext.Habitaciones.Update(habitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (HabitacionException)
        {
            throw new HabitacionException();
        }
    }

    public void DeleteHabitacion(Habitacion habitacion)
    {
        try
        {
            hotelContext.Habitaciones.Remove(habitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (HabitacionException)
        {
            throw new HabitacionException();
        }
    }
}
