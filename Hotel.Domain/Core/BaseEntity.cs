namespace Hotel.Domain;

public abstract class BaseEntity
{
    public bool? Estado { get; set; }
    public DateTime? FechaCreacion { get; set; }
}
