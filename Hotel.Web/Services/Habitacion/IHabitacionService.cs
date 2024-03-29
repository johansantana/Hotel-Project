using Hotel.Application.Dtos;
using Hotel.Web.Models.Habitacion;

namespace Hotel.Web.Services.Habitacion
{
    public interface IHabitacionService : IBaseService<HabitacionListResult, HabitacionResult, HabitacionAddDto, HabitacionUpdateDto>
    {
    }
}
