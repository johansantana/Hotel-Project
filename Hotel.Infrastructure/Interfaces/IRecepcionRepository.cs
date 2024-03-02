namespace Hotel.Infrastructure;

public interface IRecepcioRepository
{
    void CheckIn(Guest guest);
    void CheckOut(Guest guest);
    Reservation MakeReservation(Guest guest, DateTime checkInDate, DateTime checkOutDate);
}
