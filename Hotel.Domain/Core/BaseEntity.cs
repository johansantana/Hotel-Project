namespace Hotel.Domain;

public class BaseEntity 
{
    public BaseEntity()
    {
        Estado = false;
        FechaCreacion = new DateTime();
    }

    public bool? Estado { get; set; }
    public DateTime? FechaCreacion { get; set; }
}
