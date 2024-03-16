using Hotel.Application.Models;
using Hotel.Application.Dtos;

namespace Hotel.Application.Contracts;

public interface IUsuarioService : IBaseService<UsuarioGetModel, UsuarioAddDto, UsuarioUpdateDto, UsuarioDeleteDto>
{
}
