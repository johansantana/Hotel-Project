using Hotel.Infrastructure;
using Hotel.Web.Services.RolUsuario;

namespace Hotel.Web.Exceptions;

public class RolUsuarioServiceException : BaseException<RolUsuarioService>
{
    public RolUsuarioServiceException()
    {
    }

    public RolUsuarioServiceException(string message)
        : base(message)
    {
    }

    public RolUsuarioServiceException(string message, LoggerAdapter<RolUsuarioService> logger)
        : base(message)
    {
        this.logger = logger;
        this.logger.LogError(message);
        SendEmail(message);
    }
}
