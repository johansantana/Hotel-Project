

using Hotel.Aplication.Core;

namespace Hotel.Aplication.Dtos.Categoria
{
    public record CategoriaDtoBase : BaseDto
    {
        public string? Descripcion { get; set; }
    }
}
