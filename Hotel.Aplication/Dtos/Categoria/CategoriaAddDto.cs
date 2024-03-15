

namespace Hotel.Aplication.Dtos.Categoria
{
    public record CategoriaAddDto : CategoriaDtoBase
    {
        public DateTime? FechaCreacion { get; set; }
    }
}
