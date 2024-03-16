using Hotel.Infrastructure;
using Hotel.Application.Services;

namespace Hotel.Application.Exceptions;

public class HabitacionServiceException : BaseException<HabitacionService>
{
    public HabitacionServiceException()
    {
    }

    public HabitacionServiceException(string message)
        : base(message)
    {
    }

    public HabitacionServiceException(string message, LoggerAdapter<HabitacionService> logger)
        : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}