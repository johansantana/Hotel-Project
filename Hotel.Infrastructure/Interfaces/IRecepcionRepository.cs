namespace Hotel.Infrastructure.Interfaces
{
    public interface IRecepcionRepository : IBaseRepository<Recepcion>
    {
        IEnumerable<Recepcion> GetRecepciones();
        Recepcion? GetRecepcion(int idRecepcion);
        void SaveRecepcion(Recepcion recepcion);
        void RemoveRecepcion(Recepcion recepcion);
        void UpdateRecepcion(Recepcion recepcion);
        IEnumerable<Recepcion> FindRecepcionesByCriteria(Func<Recepcion, bool> criteria);
    }
}
