using Hotel.Infrastructure;
using Hotel.Application.Services;

namespace Hotel.Application.Exceptions;

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
