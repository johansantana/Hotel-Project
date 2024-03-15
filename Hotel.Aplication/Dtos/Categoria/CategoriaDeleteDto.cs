

namespace Hotel.Aplication.Dtos.Categoria
{
    public record  CategoriaDeleteDto : CategoriaDtoBase
    {
        public int IdCategoria { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime FechaBorrrada { get; set; }
        
    }
}
