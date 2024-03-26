using Hotel.Aplication.Dtos.Categoria;
using Hotel.Web.Core;
using Hotel.Web.Models;

namespace Hotel.Web.Contracts.Categoria
{
    public interface ICategoriaServise : IBaseService<CategoriaDefaultResult, CategoriaSingleResult, CategoriaAddDto, CategoriaUpdateDto>
    {
    }
}
