using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Entities
{
    public class Piso : BaseEntity
    {
        public required int IdPiso {  get; set; }
        public string? Descripcion { get; set; }
    }
}
