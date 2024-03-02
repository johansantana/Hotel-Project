using Hotel.Infrastructure;
using Microsoft.Extensions.Logging;
using Hotel.Domain;

public class RecepcionRepository : BaseRepository<Recepcion>, IRecepcionRepository
{
    public RecepcionRepository(HotelContext context) : base(context)
    {
    }

    public void CheckIn(Guest guest)
    {
    }

    public void CheckOut(Guest guest)
    {
    }

    public Reservation MakeReservation(Guest guest, DateTime checkInDate, DateTime checkOutDate)
    {
    }
}
