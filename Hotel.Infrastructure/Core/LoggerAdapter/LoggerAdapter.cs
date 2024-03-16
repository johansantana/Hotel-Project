namespace Hotel.Infrastructure;
using Microsoft.Extensions.Logging;

public class LoggerAdapter<T> : ILoggerAdapter<T> where T : class
{
    private readonly ILogger<T> logger;

    public LoggerAdapter(ILogger<T> logger)
    {
        this.logger = logger;
    }

    public void LogError(string message)
    {
        logger.LogError(message);
    }

    public void LogInfo(string message)
    {
        logger.LogInformation(message);
    }

    public void LogWarn(string message)
    {
        logger.LogWarning(message);
    }
}