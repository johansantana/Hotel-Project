
using System.ComponentModel.DataAnnotations;
using Hotel.Domain.Core;

namespace Hotel.Domain;
public class Categoria : BaseEntity
{
    [Key]
    public int IdCategoria { get; set; }
    public string? Descripcion { get; set; }
}