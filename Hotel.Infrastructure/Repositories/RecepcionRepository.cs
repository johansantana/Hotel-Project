using Hotel.Domain.Entities;
using Hotel.Domain.Repository;
using Hotel.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Infrastructure.Repositories
{
    public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
    {
        public RecepcionRepository(HotelContext hotelContext) : base(hotelContext)
        {
        }

        public new List<Recepcion> GetEntities()
        {
            return base.GetEntities();
        }

        public new Recepcion? GetEntity(int id)
        {
            return base.GetEntity(id);
        }

        public new void Add(Recepcion entity)
        {
            base.Add(entity);
        }

        public new void Update(Recepcion entity)
        {
            base.Update(entity);
        }

        public new void Remove(Recepcion entity)
        {
            base.Remove(entity);
        }

        public new List<Recepcion> FindAll(Func<Recepcion, bool> filter)
        {
            return base.FindAll(filter);
        }

        public new bool Exists(Func<Recepcion, bool> filter)
        {
            return base.Exists(filter);
        }
    }
}
