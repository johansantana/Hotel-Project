using Hotel.Application.Models;

namespace Hotel.Web.Models.Usuario
{
    public class UsuarioListResult : BaseResult
    {
        public List<UsuarioGetModel>? data { get; set; }
    }
}
