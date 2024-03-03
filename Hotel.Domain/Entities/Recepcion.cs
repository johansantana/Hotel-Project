namespace Hotel.Domain.Entities
{
    public class Recepcion : BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaDeEntrada { get; set; } 
        public DateTime? FechaDeSalida { get; set; } 
        public new string? Estado { get; set; } 
        public string? NombreDelHuesped { get; set; }
        public string? ApellidoDelHuesped { get; set; }
        public string? DocumentoIdentificacion { get; set; }
    }
}
