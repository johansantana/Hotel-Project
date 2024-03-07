using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Dtos.Categoria
{
    public class CategoriaUpdateDto : CategoriaDtoBase
    {
        public int IdCategoria { get; set; }
    }
}
