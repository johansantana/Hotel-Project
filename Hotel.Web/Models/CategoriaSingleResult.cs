using Hotel.Aplication.Models.Categoria;

namespace Hotel.Web.Models
{
    public class CategoriaSingleResult
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public CategoriaGetModel? Data { get; set; }
    }
}
