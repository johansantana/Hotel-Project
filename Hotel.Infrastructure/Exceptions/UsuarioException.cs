namespace Hotel.Infrastructure;

public class UsuarioException : BaseException<UsuarioRepository>
{
    public UsuarioException()
    {
    }

    public UsuarioException(string message) : base(message)
    {
    }

    public UsuarioException(string message, LoggerAdapter<UsuarioRepository> logger) : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}
