using Hotel.Application.Models;
using Hotel.Application.Dtos;

namespace Hotel.Application.Contracts;

public interface IRolUsuarioService : IBaseService<RolUsuarioGetModel, RolUsuarioAddDto, RolUsuarioUpdateDto, RolUsuarioDeleteDto>
{
}
