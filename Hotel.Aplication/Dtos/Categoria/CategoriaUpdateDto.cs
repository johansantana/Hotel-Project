using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Aplication.Dtos.Categoria
{
    public record  CategoriaUpdateDto : CategoriaDtoBase
    {
        public int IdCategoria { get; set; }
    }
}
