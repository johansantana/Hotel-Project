using Hotel.Application.Dtos;
using Hotel.Application.Models;

namespace Hotel.Application.Contracts;

public interface IEstadoHabitacionService : IBaseService<EstadoHabitacionGetModel, EstadoHabitacionAddDto, EstadoHabitacionUpdateDto, EstadoHabitacionDeleteDto>
{

}
