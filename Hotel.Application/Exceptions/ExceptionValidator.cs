using Hotel.Infrastructure;

namespace Hotel.Application.Exceptions;

public class ExceptionValidator<TService> where TService : class
{
    protected LoggerAdapter<TService> logger;
    public bool valid { get; set; } = true;

    public ExceptionValidator(LoggerAdapter<TService> logger)
    {
        this.logger = logger;
    }

    public void ValidateId(int id, string message)
    {
        if (id <= 0)
        {
            logger.LogWarn(message);
            valid = false;
        }
    }

    public void ValidateString(string value, string message)
    {
        if (string.IsNullOrEmpty(value))
        {
            logger.LogWarn(message);
            valid = false;
        }
    }
}