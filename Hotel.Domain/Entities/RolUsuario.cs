using Hotel.Domain.Core;

namespace Hotel.Domain;

public class RolUsuario : BaseEntity
{
    public required int IdRolUsuario { get; set; }
    public string? Description { get; set; }
}
