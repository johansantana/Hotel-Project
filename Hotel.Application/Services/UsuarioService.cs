using Hotel.Application.Contracts;
using Hotel.Application.Dtos;
using Hotel.Application.Models;
using Hotel.Application.Core;
using Hotel.Infrastructure;
using Hotel.Application.Exceptions;

namespace Hotel.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly LoggerAdapter<UsuarioService> logger;
    private readonly IUsuarioRepository usuarioRepository;


    public UsuarioService(LoggerAdapter<UsuarioService> logger, IUsuarioRepository usuarioRepository)
    {
        this.logger = logger;
        this.usuarioRepository = usuarioRepository;
    }

    public ServiceResult<List<UsuarioGetModel>> Get()
    {
        ServiceResult<List<UsuarioGetModel>> result = new ServiceResult<List<UsuarioGetModel>>();

        try
        {
            result.Data = usuarioRepository.GetEntities().Select(us => new UsuarioGetModel
            {
                IdUsuario = us.IdUsuario,
                NombreCompleto = us.NombreCompleto,
                Correo = us.Correo,
                IdRolUsuario = us.IdRolUsuario,
                Clave = us.Clave,
                Estado = us.Estado,
                FechaCreacion = us.FechaCreacion
            }).ToList();
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new UsuarioServiceException("Error obteniendo los usuarios. " + ex.Message, logger);
        }
        return result;
    }

    public ServiceResult<UsuarioGetModel> GetById(int usuarioId)
    {
        ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();

        try
        {
            var usuario = usuarioRepository.GetEntity(usuarioId) ?? throw new UsuarioServiceException("Usuario no encontrado.");
            result.Data = new UsuarioGetModel()
            {
                IdUsuario = usuario.IdUsuario,
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdRolUsuario,
                Clave = usuario.Clave,
                Estado = usuario.Estado,
                FechaCreacion = usuario.FechaCreacion,
            };
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new UsuarioServiceException("Error obteniendo el usuario. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<UsuarioAddDto> Save(UsuarioAddDto usuario)
    {
        ServiceResult<UsuarioAddDto> result = new ServiceResult<UsuarioAddDto>();
        ExceptionValidator<UsuarioService> usuarioValidator = new ExceptionValidator<UsuarioService>(logger);

        try
        {
            result.Data = usuario;
            usuarioValidator.ValidateId(usuario.IdRolUsuario, "El rol de usuario no puede ser menor o igual que 0.");

            if (!usuarioValidator.valid)
            {
                result.Success = false;
                return result;
            }
            usuarioRepository.Add(new Usuario()
            {
                NombreCompleto = usuario.NombreCompleto,
                Correo = usuario.Correo,
                IdRolUsuario = usuario.IdRolUsuario,
                Clave = usuario.Clave,
                Estado = usuario.Estado,
                FechaCreacion = DateTime.Now
            });

            if (usuarioRepository.Exists(us => us.Correo == usuario.Correo))
            {
                result.Success = false;
                throw new UsuarioServiceException("El usuario ya se encuentra registrado.");
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new UsuarioServiceException("Error guardando el usuario. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<UsuarioUpdateDto> Update(int usuarioId, UsuarioUpdateDto usuario)
    {
        ServiceResult<UsuarioUpdateDto> result = new ServiceResult<UsuarioUpdateDto>();
        ExceptionValidator<UsuarioService> usuarioValidator = new ExceptionValidator<UsuarioService>(logger);

        try
        {
            usuarioValidator.ValidateId(usuarioId, "El id del usuario no puede ser menor o igual que 0.");
            usuarioValidator.ValidateId(usuario.IdRolUsuario, "El rol de usuario no puede ser menor o igual que 0.");
            if (usuarioValidator.valid == false)
            {
                result.Success = false;
                return result;
            }

            result.Data = usuario;

            var usuarioToUpdate = usuarioRepository.GetEntity(usuarioId);
            if (usuarioToUpdate == null)
            {
                result.Success = false;
                throw new UsuarioServiceException("Usuario no encontrado.");
            }

            usuarioToUpdate.Clave = usuario.Clave;
            usuarioToUpdate.Correo = usuario.Correo;
            usuarioToUpdate.NombreCompleto = usuario.NombreCompleto;
            usuarioToUpdate.Estado = usuario.Estado;
            usuarioToUpdate.IdRolUsuario = usuario.IdRolUsuario;
            usuarioRepository.Update(usuarioToUpdate);

        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new UsuarioServiceException("Error actualizando el usuario. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<UsuarioDeleteDto> Delete(int usuarioId)
    {
        ServiceResult<UsuarioDeleteDto> result = new ServiceResult<UsuarioDeleteDto>();
        ExceptionValidator<UsuarioService> usuarioValidator = new ExceptionValidator<UsuarioService>(logger);

        try
        {
            usuarioValidator.ValidateId(usuarioId, "El id del usuario no puede ser menor o igual que 0.");
            if (usuarioValidator.valid == false)
            {
                result.Success = false;
                return result;
            }

            var usuarioDeleted = usuarioRepository.GetEntity(usuarioId);

            if (usuarioDeleted == null)
            {
                result.Success = false;
                throw new UsuarioServiceException("Usuario no encontrado.");
            }

            usuarioRepository.Remove(usuarioDeleted);
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new UsuarioServiceException("Error eliminando el usuario. " + ex.Message, logger);
        }

        return result;
    }
}
