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
        IEnumerable<PisoModel> GetPisos();
        PisoModel? GetPiso(int IdPiso);
        void SavePiso(PisoModel piso);
        void RemovePiso(PisoModel piso);
        void UpdatePiso(PisoModel piso);
    }
}
