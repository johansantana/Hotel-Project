using Hotel.Application.Contracts;
using Hotel.Application.Dtos;
using Hotel.Application.Models;
using Hotel.Application.Core;
using Hotel.Infrastructure;
using Hotel.Application.Exceptions;

namespace Hotel.Application.Services;

public class EstadoHabitacionService : IEstadoHabitacionService
{
    private readonly LoggerAdapter<EstadoHabitacionService> logger;
    private readonly IEstadoHabitacionRepository estadoHabitacionRepository;


    public EstadoHabitacionService(LoggerAdapter<EstadoHabitacionService> logger, IEstadoHabitacionRepository estadoHabitacionRepository)
    {
        this.logger = logger;
        this.estadoHabitacionRepository = estadoHabitacionRepository;
    }

    public ServiceResult<List<EstadoHabitacionGetModel>> Get()
    {
        ServiceResult<List<EstadoHabitacionGetModel>> result = new ServiceResult<List<EstadoHabitacionGetModel>>();

        try
        {
            result.Data = estadoHabitacionRepository.GetEntities().Select(eh => new EstadoHabitacionGetModel
            {
                IdEstadoHabitacion = eh.IdEstadoHabitacion,
                Descripcion = eh.Descripcion,
                Estado = eh.Estado,
                FechaCreacion = eh.FechaCreacion
            }).ToList();
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new EstadoHabitacionServiceException("Error obteniendo los estados de habitación. " + ex.Message, logger);
        }
        return result;
    }

    public ServiceResult<EstadoHabitacionGetModel> GetById(int estadoHabitacionId)
    {
        ServiceResult<EstadoHabitacionGetModel> result = new ServiceResult<EstadoHabitacionGetModel>();

        try
        {
            var estadoHabitacion = estadoHabitacionRepository.GetEntity(estadoHabitacionId) ?? throw new EstadoHabitacionServiceException("Estado de habitación no encontrado.");
            result.Data = new EstadoHabitacionGetModel()
            {
                IdEstadoHabitacion = estadoHabitacion.IdEstadoHabitacion,
                Descripcion = estadoHabitacion.Descripcion,
                Estado = estadoHabitacion.Estado,
                FechaCreacion = estadoHabitacion.FechaCreacion,
            };
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new EstadoHabitacionServiceException("Error obteniendo el estado de habitación. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<EstadoHabitacionAddDto> Save(EstadoHabitacionAddDto estadoHabitacion)
    {
        ServiceResult<EstadoHabitacionAddDto> result = new ServiceResult<EstadoHabitacionAddDto>();

        try
        {
            result.Data = estadoHabitacion;
            estadoHabitacionRepository.Add(new EstadoHabitacion()
            {
                IdEstadoHabitacion = estadoHabitacion.Id,
                Descripcion = estadoHabitacion.Descripcion,
                Estado = estadoHabitacion.Estado,
                FechaCreacion = DateTime.Now
            });

            if (estadoHabitacionRepository.Exists(eh => eh.Descripcion == estadoHabitacion.Descripcion))
            {
                result.Success = false;
                throw new EstadoHabitacionServiceException("El estado de habitación ya se encuentra registrado.");
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new EstadoHabitacionServiceException("Error guardando el estado de habitación. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<EstadoHabitacionUpdateDto> Update(int estadoHabitacionId, EstadoHabitacionUpdateDto estadoHabitacion)
    {
        ServiceResult<EstadoHabitacionUpdateDto> result = new ServiceResult<EstadoHabitacionUpdateDto>();

        try
        {
            result.Data = estadoHabitacion;

            var estadoHabitacionToUpdate = estadoHabitacionRepository.GetEntity(estadoHabitacionId);
            if (estadoHabitacionToUpdate == null)
            {
                result.Success = false;
                throw new EstadoHabitacionServiceException("Estado de habitación no encontrado.");
            }

            estadoHabitacionToUpdate.Descripcion = estadoHabitacion.Descripcion;
            estadoHabitacionToUpdate.Estado = estadoHabitacion.Estado;
            estadoHabitacionRepository.Update(estadoHabitacionToUpdate);

        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new EstadoHabitacionServiceException("Error actualizando el estado de habitación. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<EstadoHabitacionDeleteDto> Delete(int estadoHabitacionId)
    {
        ServiceResult<EstadoHabitacionDeleteDto> result = new ServiceResult<EstadoHabitacionDeleteDto>();
        ExceptionValidator<EstadoHabitacionService> usuarioValidator = new ExceptionValidator<EstadoHabitacionService>(logger);

        try
        {
            usuarioValidator.ValidateId(estadoHabitacionId, "El id del usuario no puede ser menor o igual que 0.");
            if (usuarioValidator.valid == false)
            {
                result.Success = false;
                return result;
            }

            var estadoHabitacionDeleted = estadoHabitacionRepository.GetEntity(estadoHabitacionId);

            if (estadoHabitacionDeleted == null)
            {
                result.Success = false;
                throw new EstadoHabitacionServiceException("Estado de habitación no encontrado.");
            }

            estadoHabitacionRepository.Remove(estadoHabitacionDeleted);
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new EstadoHabitacionServiceException("Error eliminando el estado de habitación. " + ex.Message, logger);
        }

        return result;
    }
}