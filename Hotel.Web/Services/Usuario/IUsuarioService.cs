using Hotel.Application.Dtos;
using Hotel.Web.Models.Usuario;

namespace Hotel.Web.Services.Usuario
{
    public interface IUsuarioService : IBaseService<UsuarioListResult, UsuarioResult, UsuarioAddDto, UsuarioUpdateDto>
    {
    }
}
