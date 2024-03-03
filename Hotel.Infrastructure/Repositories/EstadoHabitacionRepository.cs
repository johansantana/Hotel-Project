using Hotel.Domain.Repository;

namespace Hotel.Infrastructure;

public class EstadoHabitacionRepository : IBaseRepository, IEstadoHabitacionRepository
{
    private readonly HotelContext hotelContext;

    public EstadoHabitacionRepository(HotelContext hotelContext)
    {
        this.hotelContext = hotelContext;
    }

    public IEnumerable<EstadoHabitacion> GetEstadoHabitaciones()
    {
        try
        {
            return hotelContext.EstadoHabitaciones;
        }
        catch (Exception)
        {
            throw new EstadoHabitacionException();
        }
    }

    public EstadoHabitacion? GetEstadoHabitacion(int idEstadoHabitacion)
    {
        try
        {
            return hotelContext.EstadoHabitaciones
                .FirstOrDefault(estadoHabitacion => estadoHabitacion.IdEstadoHabitacion == idEstadoHabitacion);
        }
        catch (Exception)
        {
            throw new EstadoHabitacionException();
        }
    }

    public void AddEstadoHabitacion(EstadoHabitacion estadoHabitacion)
    {
        try
        {
            hotelContext.EstadoHabitaciones.Add(estadoHabitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new EstadoHabitacionException();
        }
    }

    public void UpdateEstadoHabitacion(EstadoHabitacion estadoHabitacion)
    {
        try
        {
            hotelContext.EstadoHabitaciones.Update(estadoHabitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new EstadoHabitacionException();
        }
    }

    public void DeleteEstadoHabitacion(EstadoHabitacion estadoHabitacion)
    {
        try
        {
            hotelContext.EstadoHabitaciones.Remove(estadoHabitacion);
            hotelContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new EstadoHabitacionException();
        }
    }
}

public interface IBaseRepository
{
}