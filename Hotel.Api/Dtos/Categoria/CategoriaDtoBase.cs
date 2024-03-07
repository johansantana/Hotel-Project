using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Dtos.Categoria
{
    public class CategoriaDtoBase : DtoBase
    {
        public string? Descripcion { get; set; }
    }
}
