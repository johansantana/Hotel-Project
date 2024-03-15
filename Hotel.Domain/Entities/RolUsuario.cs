namespace Hotel.Domain;
using System.ComponentModel.DataAnnotations;

public class RolUsuario : BaseEntity
{
    [Key]
    public required int IdRolUsuario { get; set; }
    public string? Description { get; set; }
}
