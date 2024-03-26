using Hotel.Aplication.Models.Categoria;
using Hotel.Web.Core;

namespace Hotel.Web.Models
{
    public class CategoriaSingleResult : BaseResult
    {
        public  CategoriaGetModel? Data { get; set; }
    }
}
