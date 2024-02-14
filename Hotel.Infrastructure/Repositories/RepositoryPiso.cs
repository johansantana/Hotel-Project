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
            return hotelContext.pisos;
        }

        public Piso? GetPiso(int IdPiso) => hotelContext.pisos
            .FirstOrDefault(cd => cd.IdPiso == IdPiso);

        public void Save(Piso piso)
        {
            hotelContext.pisos.Add(piso);
        }

        public void Remove(Piso piso)
        {
            hotelContext.pisos.Remove(piso);
        }

        public void Update(Piso piso)
        {
            hotelContext.pisos.Update(piso);
        }
    }
}
