using Hotel.Infrastructure;
using Hotel.Application.Services;

namespace Hotel.Application.Exceptions;

public class EstadoHabitacionServiceException : BaseException<EstadoHabitacionService>
{
    public EstadoHabitacionServiceException()
    {
    }

    public EstadoHabitacionServiceException(string message)
        : base(message)
    {
    }

    public EstadoHabitacionServiceException(string message, LoggerAdapter<EstadoHabitacionService> logger)
        : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}