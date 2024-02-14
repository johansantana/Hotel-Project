using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Models
{
    public abstract class Piso
    {
        public int IdPiso { get; set; }
        public DateTime FechaCreacion { get; set; } = new DateTime();

    }
}
