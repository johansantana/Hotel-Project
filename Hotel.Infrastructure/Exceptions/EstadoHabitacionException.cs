using Hotel.Application;

namespace Hotel.Infrastructure;

public class EstadoHabitacionException : BaseException<EstadoHabitacionRepository>
{
    public EstadoHabitacionException()
    {
    }

    public EstadoHabitacionException(string message) : base(message)
    {
    }

    public EstadoHabitacionException(string message, LoggerAdapter<EstadoHabitacionRepository> logger) : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}
