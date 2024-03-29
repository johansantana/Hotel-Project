using Hotel.Application.Dtos;
using Hotel.Web.Models.RolUsuario;
using Hotel.Web.Models.Usuario;

namespace Hotel.Web.Services.RolUsuario
{
    public interface IRolUsuarioService : IBaseService<RolUsuarioListResult, RolUsuarioResult, RolUsuarioAddDto, RolUsuarioUpdateDto>
    {
    }
}
