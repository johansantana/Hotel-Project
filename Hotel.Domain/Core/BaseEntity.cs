namespace Hotel.Domain.Core;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        Estado = false;
        FechaCreacion = new DateTime();
    }

    public bool? Estado { get; set; }
    public DateTime? FechaCreacion { get; set; }
}
