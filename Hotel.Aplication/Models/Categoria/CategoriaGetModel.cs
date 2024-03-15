
using System.ComponentModel.DataAnnotations;


namespace Hotel.Aplication.Models.Categoria
{
    public class CategoriaGetModel
    {
        [Key]
        public int IdCategoria { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
