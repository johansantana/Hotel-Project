
using System.ComponentModel.DataAnnotations;

namespace Hotel.Domain;
public class Categoria : BaseEntity
{
    [Key]
    public int IdCategoria { get; set; }
    public string? Descripcion { get; set; }
}