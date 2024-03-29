using Hotel.Application.Models;

namespace Hotel.Web.Models.RolUsuario
{
    public class RolUsuarioListResult : BaseResult
    {
        public List<RolUsuarioGetModel>? data { get; set; }
    }
}
