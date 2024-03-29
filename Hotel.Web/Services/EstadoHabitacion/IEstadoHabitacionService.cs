using Hotel.Application.Dtos;
using Hotel.Web.Models.EstadoHabitacion;

namespace Hotel.Web.Services.EstadoHabitacion
{
    public interface IEstadoHabitacionService : IBaseService<EstadoHabitacionListResult, EstadoHabitacionResult, EstadoHabitacionAddDto, EstadoHabitacionUpdateDto>
    {
    }
}
