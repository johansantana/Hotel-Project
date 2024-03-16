using Hotel.Application.Dtos;
using Hotel.Application.Models;

namespace Hotel.Application.Contracts;

public interface IHabitacionService : IBaseService<HabitacionGetModel, HabitacionAddDto, HabitacionUpdateDto, HabitacionDeleteDto>
{
}
