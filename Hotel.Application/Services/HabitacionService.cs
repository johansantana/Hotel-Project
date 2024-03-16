using Hotel.Application.Contracts;
using Hotel.Application.Dtos;
using Hotel.Application.Models;
using Hotel.Application.Core;
using Hotel.Infrastructure;
using Hotel.Application.Exceptions;

namespace Hotel.Application.Services;

public class HabitacionService : IHabitacionService
{
    private readonly LoggerAdapter<HabitacionService> logger;
    private readonly IHabitacionRepository habitacionRepository;


    public HabitacionService(LoggerAdapter<HabitacionService> logger, IHabitacionRepository habitacionRepository)
    {
        this.logger = logger;
        this.habitacionRepository = habitacionRepository;
    }

    public ServiceResult<List<HabitacionGetModel>> Get()
    {
        ServiceResult<List<HabitacionGetModel>> result = new ServiceResult<List<HabitacionGetModel>>();

        try
        {
            result.Data = habitacionRepository.GetEntities().Select(ha => new HabitacionGetModel
            {
                IdHabitacion = ha.IdHabitacion,
                Numero = ha.Numero,
                IdPiso = ha.IdPiso,
                IdCategoria = ha.IdCategoria,
                IdEstadoHabitacion = ha.IdEstadoHabitacion,
                Detalle = ha.Detalle,
                Precio = ha.Precio,
                Estado = ha.Estado,
                FechaCreacion = ha.FechaCreacion
            }).ToList();
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new HabitacionServiceException("Error obteniendo las habitaciones. " + ex.Message, logger);
        }
        return result;
    }

    public ServiceResult<HabitacionGetModel> GetById(int habitacionId)
    {
        ServiceResult<HabitacionGetModel> result = new ServiceResult<HabitacionGetModel>();

        try
        {
            var habitacion = habitacionRepository.GetEntity(habitacionId) ?? throw new HabitacionServiceException("Habitación no encontrada.");
            result.Data = new HabitacionGetModel()
            {
                IdHabitacion = habitacion.IdHabitacion,
                Numero = habitacion.Numero,
                IdPiso = habitacion.IdPiso,
                IdCategoria = habitacion.IdCategoria,
                IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                Detalle = habitacion.Detalle,
                Precio = habitacion.Precio,
                Estado = habitacion.Estado,
                FechaCreacion = habitacion.FechaCreacion,
            };
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new HabitacionServiceException("Error obteniendo la habitación. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<HabitacionAddDto> Save(HabitacionAddDto habitacion)
    {
        ServiceResult<HabitacionAddDto> result = new ServiceResult<HabitacionAddDto>();
        ExceptionValidator<HabitacionService> habitacionValidator = new ExceptionValidator<HabitacionService>(logger);

        try
        {
            result.Data = habitacion;
            habitacionValidator.ValidateId(habitacion.IdPiso, "El piso no puede ser menor o igual que 0.");
            habitacionValidator.ValidateId(habitacion.IdCategoria, "La categoría no puede ser menor o igual que 0.");
            habitacionValidator.ValidateId(habitacion.IdEstadoHabitacion, "El estado de la habitación no puede ser menor o igual que 0.");

            if (!habitacionValidator.valid)
            {
                result.Success = false;
                return result;
            }
            habitacionRepository.Add(new Habitacion()
            {
                Numero = habitacion.Numero,
                IdPiso = habitacion.IdPiso,
                IdCategoria = habitacion.IdCategoria,
                IdEstadoHabitacion = habitacion.IdEstadoHabitacion,
                Detalle = habitacion.Detalle,
                Precio = habitacion.Precio,
                Estado = habitacion.Estado,
                FechaCreacion = DateTime.Now
            });

            if (habitacionRepository.Exists(ha => ha.Numero == habitacion.Numero))
            {
                result.Success = false;
                throw new HabitacionServiceException("La habitación ya se encuentra registrado.");
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new HabitacionServiceException("Error guardando la habitación. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<HabitacionUpdateDto> Update(int habitacionId, HabitacionUpdateDto habitacion)
    {
        ServiceResult<HabitacionUpdateDto> result = new ServiceResult<HabitacionUpdateDto>();
        ExceptionValidator<HabitacionService> habitacionValidator = new ExceptionValidator<HabitacionService>(logger);

        try
        {
            habitacionValidator.ValidateId(habitacionId, "El id de la habitación no puede ser menor o igual que 0.");
            habitacionValidator.ValidateId(habitacion.IdPiso, "El piso no puede ser menor o igual que 0.");
            habitacionValidator.ValidateId(habitacion.IdCategoria, "La categoría no puede ser menor o igual que 0.");
            habitacionValidator.ValidateId(habitacion.IdEstadoHabitacion, "El estado de la habitación no puede ser menor o igual que 0.");

            if (habitacionValidator.valid == false)
            {
                result.Success = false;
                return result;
            }

            result.Data = habitacion;

            var habitacionToUpdate = habitacionRepository.GetEntity(habitacionId);
            if (habitacionToUpdate == null)
            {
                result.Success = false;
                throw new HabitacionServiceException("Habitacion no encontrada.");
            }

            habitacionToUpdate.Numero = habitacion.Numero;
            habitacionToUpdate.IdPiso = habitacion.IdPiso;
            habitacionToUpdate.IdCategoria = habitacion.IdCategoria;
            habitacionToUpdate.IdEstadoHabitacion = habitacion.IdEstadoHabitacion;
            habitacionToUpdate.Detalle = habitacion.Detalle;
            habitacionToUpdate.Precio = habitacion.Precio;
            habitacionToUpdate.Estado = habitacion.Estado;
            habitacionRepository.Update(habitacionToUpdate);

        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new HabitacionServiceException("Error actualizando la habitación. " + ex.Message, logger);
        }

        return result;
    }

    public ServiceResult<HabitacionDeleteDto> Delete(int habitacionId)
    {
        ServiceResult<HabitacionDeleteDto> result = new ServiceResult<HabitacionDeleteDto>();
        ExceptionValidator<HabitacionService> habitacionValidator = new ExceptionValidator<HabitacionService>(logger);

        try
        {
            habitacionValidator.ValidateId(habitacionId, "El id de la habitación no puede ser menor o igual que 0.");
            if (habitacionValidator.valid == false)
            {
                result.Success = false;
                return result;
            }

            var habitacionDeleted = habitacionRepository.GetEntity(habitacionId);

            if (habitacionDeleted == null)
            {
                result.Success = false;
                throw new HabitacionServiceException("Habitación no encontrada.");
            }

            habitacionRepository.Remove(habitacionDeleted);
        }
        catch (Exception ex)
        {
            result.Success = false;
            throw new HabitacionServiceException("Error eliminando la habitación. " + ex.Message, logger);
        }

        return result;
    }
}
