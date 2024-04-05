using Hotel.Infrastructure;
using Hotel.Web.Services.Usuario;

namespace Hotel.Web.Exceptions;

public class UsuarioServiceException : BaseException<UsuarioService>
{
    public UsuarioServiceException()
    {
    }

    public UsuarioServiceException(string message)
        : base(message)
    {
    }

    public UsuarioServiceException(string message, LoggerAdapter<UsuarioService> logger)
        : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}
