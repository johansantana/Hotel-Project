namespace Hotel.Infrastructure.Models
{
    public class RecepcionModel
    {

        public int Id { get; set; }
        public string? NombreDelHuesped { get; set; }
        public DateTime FechaDeEntrada { get; set; }
        public DateTime? FechaDeSalida { get; set; }
    }
}
