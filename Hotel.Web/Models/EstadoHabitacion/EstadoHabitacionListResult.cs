using Hotel.Application.Models;

namespace Hotel.Web.Models.EstadoHabitacion
{
    public class EstadoHabitacionListResult : BaseResult
    {
        public List<EstadoHabitacionGetModel>? data { get; set; }
    }
}
