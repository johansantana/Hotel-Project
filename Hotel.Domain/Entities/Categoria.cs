
namespace Hotel.Domain;
public class Categoria : BaseEntity
{
    public required int IdCategoria { get; set; }
    public string? Description { get; set; }
}