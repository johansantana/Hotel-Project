namespace Hotel.Infrastructure;

public class RolUsuarioException : BaseException<RolUsuarioRepository>
{
    public RolUsuarioException()
    {
    }

    public RolUsuarioException(string message) : base(message)
    {
    }

    public RolUsuarioException(string message, LoggerAdapter<RolUsuarioRepository> logger) : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}
