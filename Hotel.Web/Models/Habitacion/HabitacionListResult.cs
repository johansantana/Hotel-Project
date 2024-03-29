using Hotel.Application.Models;

namespace Hotel.Web.Models.Habitacion
{
    public class HabitacionListResult : BaseResult
    {
        public List<HabitacionGetModel>? data { get; set; }
    }
}
