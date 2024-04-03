using Hotel.Aplication.Models.Categoria;
using Hotel.ApiConsumption.Core;

namespace Hotel.ApiConsumption.Models
{
    public class CategoriaSingleResult : BaseResult
    {
        public  CategoriaGetModel? Data { get; set; }
    }
}
