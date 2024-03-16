using Hotel.Application.Contracts;
using Hotel.Application.Dtos;
using Hotel.Application.Models;
using Hotel.Application.Core;
using Hotel.Infrastructure;
using Hotel.Application.Exceptions;

namespace Hotel.Application.Services;

public class RolUsuarioService : IRolUsuarioService
{
    private readonly LoggerAdapter<RolUsuarioService> logger;
    private readonly IRolUsuarioRepository rolUsuarioRepository;


    public RolUsuarioService(LoggerAdapter<RolUsuarioService> logger, IRolUsuarioRepository rolUsuarioRepository)
    {
        this.logger = logger;
        this.rolUsuarioRepository = rolUsuarioRepository;
    }

    public ServiceResult<List<RolUsuarioGetModel>> Get()
    {
        ServiceResult<List<RolUsuarioGetModel>> result = new ServiceResult<List<RolUsuarioGetModel>>();

        try
        {
            result.Data = rolUsuarioRepository.GetEntities().Select(us => new RolUsuarioGetModel
            {
                IdRolUsuario = us.IdRolUsuario,
                Estado = us.Estado,
                FechaCreacion = us.FechaCreacion,
            }).ToList();
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new RolUsuarioServiceException("Error obteniendo los usuarios. " + ex.Message, logger);
        }
        return result;
    }

    public ServiceResult<RolUsuarioGetModel> GetById(int rolUsuarioId)
    {
        ServiceResult<RolUsuarioGetModel> result = new ServiceResult<RolUsuarioGetModel>();

        try
        {
            var usuario = rolUsuarioRepository.GetEntity(rolUsuarioId) ?? throw new RolUsuarioServiceException("Rol de usuario no encontrado");
            result.Data = new RolUsuarioGetModel()
            {
                IdRolUsuario = usuario.IdRolUsuario,
                Estado = usuario.Estado,
                FechaCreacion = usuario.FechaCreacion,
                Descripcion = usuario.Descripcion
            };
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new RolUsuarioServiceException("Error obteniendo el usuario. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<RolUsuarioAddDto> Save(RolUsuarioAddDto rolUsuario)
    {
        ServiceResult<RolUsuarioAddDto> result = new ServiceResult<RolUsuarioAddDto>();

        try
        {
            result.Data = rolUsuario;
            rolUsuarioRepository.Add(new RolUsuario()
            {
                Estado = rolUsuario.Estado,
                FechaCreacion = rolUsuario.FechaCreacion,
                Descripcion = rolUsuario.Descripcion
            });

            if (rolUsuarioRepository.Exists(us => us.Descripcion == rolUsuario.Descripcion))
            {
                result.Success = false;
                throw new RolUsuarioServiceException("El rol de usuario ya se encuentra registrado");
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new RolUsuarioServiceException("Error guardando el rol de usuario, " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<RolUsuarioUpdateDto> Update(int rolUsuarioId, RolUsuarioUpdateDto rolUsuario)
    {
        ServiceResult<RolUsuarioUpdateDto> result = new ServiceResult<RolUsuarioUpdateDto>();

        try
        {
            result.Data = rolUsuario;

            var usuarioToUpdate = rolUsuarioRepository.GetEntity(rolUsuarioId);
            if (usuarioToUpdate == null)
            {
                result.Success = false;
                throw new RolUsuarioServiceException("Rol de usuario no encontrado");
            }
            usuarioToUpdate.Estado = rolUsuario.Estado;
            rolUsuarioRepository.Update(usuarioToUpdate);

        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new RolUsuarioServiceException("Error actualizando el rol de usuario " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<RolUsuarioDeleteDto> Delete(int rolUsuarioId)
    {
        ServiceResult<RolUsuarioDeleteDto> result = new ServiceResult<RolUsuarioDeleteDto>();
        ExceptionValidator<RolUsuarioService> rolUsuarioValidator = new ExceptionValidator<RolUsuarioService>(logger);

        try
        {
            rolUsuarioValidator.ValidateId(rolUsuarioId, "El id del usuario no puede ser menor o igual que 0.");
            if (rolUsuarioValidator.valid == false)
            {
                result.Success = false;
                return result;
            }

            var usuarioDeleted = rolUsuarioRepository.GetEntity(rolUsuarioId);

            if (usuarioDeleted == null)
            {
                result.Success = false;
                throw new RolUsuarioServiceException("Usuario no encontrado");
            }

            rolUsuarioRepository.Remove(usuarioDeleted);
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new RolUsuarioServiceException("Error eliminando el rol de usuario " + ex.Message, logger);
        }

        return result;
    }
}
