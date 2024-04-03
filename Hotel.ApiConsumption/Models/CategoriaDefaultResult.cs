using Hotel.Aplication.Models.Categoria;
using Hotel.ApiConsumption.Core;

namespace Hotel.ApiConsumption.Models
{
    public class CategoriaDefaultResult : BaseResult
    {
        public  List<CategoriaGetModel>? Data { get; set; }
    }
}
