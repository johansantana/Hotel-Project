namespace Hotel.Infrastructure;

public interface IEstadoHabitacionRepository
{
    IEnumerable<EstadoHabitacion> GetEstadoHabitaciones();
    EstadoHabitacion? GetEstadoHabitacion(int idEstadoHabitacion);
    void AddEstadoHabitacion(EstadoHabitacion estadoHabitacion);
    void UpdateEstadoHabitacion(EstadoHabitacion estadoHabitacion);
    void DeleteEstadoHabitacion(EstadoHabitacion estadoHabitacion);
}
