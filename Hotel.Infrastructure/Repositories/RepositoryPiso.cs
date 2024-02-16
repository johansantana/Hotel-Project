using Hotel.Infrastructure.Interfaces;
using Hotel.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Repositories
{
    public class RepositoryPiso : IPiso
    {
        private readonly HotelContext hotelContext;

        public RepositoryPiso(HotelContext hotelContext)
        {
            this.hotelContext = hotelContext;
        }

        public IEnumerable<PisoModel> GetPisos()
        {
            return hotelContext.Pisos;
        }

        public PisoModel? GetPiso(int IdPiso) => hotelContext.Pisos
            .FirstOrDefault(cd => cd.IdPiso == IdPiso);

        public void SavePiso(PisoModel piso)
        {
            hotelContext.Pisos.Add(piso);
            hotelContext.SaveChangesAsync();
        }

        public void RemovePiso(PisoModel piso)
        {
            hotelContext.Pisos.Remove(piso);
            hotelContext.SaveChangesAsync();
        }

        public void UpdatePiso(PisoModel piso)
        {
            hotelContext.Pisos.Update(piso);
            hotelContext.SaveChangesAsync();
        }
    }
}
