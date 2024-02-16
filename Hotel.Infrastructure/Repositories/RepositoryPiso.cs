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

        public IEnumerable<Piso> GetPisos()
        {
            return hotelContext.Pisos;
        }

        public Piso? GetPiso(int IdPiso) => hotelContext.Pisos
            .FirstOrDefault(cd => cd.IdPiso == IdPiso);

        public void SavePiso(Piso piso)
        {
            hotelContext.Pisos.Add(piso);
            hotelContext.SaveChangesAsync();
        }

        public void RemovePiso(Piso piso)
        {
            hotelContext.Pisos.Remove(piso);
            hotelContext.SaveChangesAsync();
        }

        public void UpdatePiso(Piso piso)
        {
            hotelContext.Pisos.Update(piso);
            hotelContext.SaveChangesAsync();
        }
    }
}
