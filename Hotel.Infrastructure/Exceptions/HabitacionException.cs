namespace Hotel.Infrastructure;

public class HabitacionException : BaseException<HabitacionRepository>
{
    public HabitacionException()
    {
    }
    public HabitacionException(string message) : base(message)
    {
    }

    public HabitacionException(string message, LoggerAdapter<HabitacionRepository> logger) : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}
