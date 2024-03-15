

namespace Hotel.Infrastructure.LoggerAdapter
{
    public interface ILoggerAdapter<T> where T : class
    {
        void LogInformacion(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogCritical(string message);

    }
}
