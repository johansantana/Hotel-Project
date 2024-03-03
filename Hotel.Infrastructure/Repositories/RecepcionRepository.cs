using Hotel.Domain.Entities;

namespace Hotel.Infrastructure.Repositories
{
    public class RecepcionRepository : IRecepcionRepository
    {
        private readonly HotelContext _hotelContext;

        public RecepcionRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public void AddRecepcion(Recepcion recepcion)
        {
            _hotelContext.Recepciones.Add(recepcion);
            _hotelContext.SaveChanges();
        }

        public void DeleteRecepcion(Recepcion recepcion)
        {
            _hotelContext.Recepciones.Remove(recepcion);
            _hotelContext.SaveChanges();
        }

        public Recepcion? GetRecepcion(int id)
        {
            return _hotelContext.Recepciones.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recepcion> GetRecepciones()
        {
            return _hotelContext.Recepciones.ToList();
        }
    }

    public interface IRecepcionRepository
    {
    }
}
