using Hotel.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IPiso 
    {
        IEnumerable<Piso> GetPisos();
        Piso? GetPiso(int IdPiso);
        void SavePiso(Piso piso);
        void RemovePiso(Piso piso);
        void UpdatePiso(Piso piso);
    }
}
