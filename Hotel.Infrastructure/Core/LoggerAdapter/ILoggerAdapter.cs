namespace Hotel.Infrastructure;

public interface ILoggerAdapter<T> where T : class
{
    void LogError(string message);
    void LogInfo(string message);
    void LogWarn(string message);
}
