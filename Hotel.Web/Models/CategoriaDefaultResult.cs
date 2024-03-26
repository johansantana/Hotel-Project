using Hotel.Aplication.Models.Categoria;
using Hotel.Web.Core;

namespace Hotel.Web.Models
{
    public class CategoriaDefaultResult : BaseResult
    {
        public  List<CategoriaGetModel>? Data { get; set; }
    }
}
