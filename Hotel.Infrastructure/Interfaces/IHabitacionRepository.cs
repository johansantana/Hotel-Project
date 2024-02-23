namespace Hotel.Infrastructure;

public interface IHabitacionRepository
{
    IEnumerable<Habitacion> GetHabitaciones();
    Habitacion? GetHabitacion(int idHabitacion);
    void AddHabitacion(Habitacion habitacion);
    void DeleteHabitacion(Habitacion habitacion);
    void UpdateHabitacion(Habitacion habitacion);
}
