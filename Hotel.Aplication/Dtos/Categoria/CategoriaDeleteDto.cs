using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Aplication.Dtos.Categoria
{
    public record  CategoriaDeleteDto : CategoriaDtoBase
    {
        public int IdCategoria { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime FechaBorrrada { get; set; }
        
    }
}
