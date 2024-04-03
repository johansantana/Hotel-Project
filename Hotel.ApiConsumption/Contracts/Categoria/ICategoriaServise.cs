using Hotel.Aplication.Dtos.Categoria;
using Hotel.ApiConsumption.Core;
using Hotel.ApiConsumption.Models;

namespace Hotel.ApiConsumption.Contracts.Categoria
{
    public interface ICategoriaServise : IBaseService<CategoriaDefaultResult, CategoriaSingleResult, CategoriaAddDto, CategoriaUpdateDto>
    {
    }
}
