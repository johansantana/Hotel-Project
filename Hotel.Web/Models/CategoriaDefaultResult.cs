using Hotel.Aplication.Models.Categoria;

namespace Hotel.Web.Models
{
    public class CategoriaDefaultResult
    {
        public bool success {  get; set; }
        public string? message { get; set;}
        public List<CategoriaGetModel>? Data { get; set; }
    }
}
