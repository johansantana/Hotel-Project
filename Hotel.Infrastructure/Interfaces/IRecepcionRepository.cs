using Hotel.Domain;

namespace Hotel.Infrastructure.Interfaces
{
    public interface IRecepcionRepository
    {
        void Create(Recepcion recepcion);
        void Update(Recepcion recepcion);
        void Remove(Recepcion recepcion);
        Recepcion GetRecepcion(int id);
        List<Recepcion> GetRecepcions();
    }
}