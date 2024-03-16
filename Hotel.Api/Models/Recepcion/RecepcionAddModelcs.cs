namespace Hotel.Api.Models
{
    public class RecepcionAddModel
    {
        public int IdRecepcion { get; set; }
        public string? NombreCliente { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public int NumeroAdultos { get; set; }
        public int NumeroNinos { get; set; }
        public bool? Pagado { get; set; }
    }
}
