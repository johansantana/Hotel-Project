

using Hotel.Aplication.Core;
using Hotel.Aplication.Dtos.Categoria;

namespace Hotel.Aplication.Exceptions.Validaciones
{
    public class CategoriaValidaciones
    {
        public CategoriaValidaciones()
        {
            
        }

        public ServiceResult<T> ValidacionesAdd<T>(ServiceResult<T> result, CategoriaAddDto categoria)
        {   
            if (string.IsNullOrEmpty(categoria.Descripcion))
            {
            result.Success = false;
            result.Message = "La descripcion no puede estar vacia";
            }
            return result;
        }
        public ServiceResult<T>  ValidacionesUpdate<T>( ServiceResult<T> result, CategoriaUpdateDto categoria)
        {
            if (string.IsNullOrEmpty(categoria.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion no puede estar vacia";
            }
            if (categoria.IdCategoria <= 0)
            {
                result.Success = false;
                result.Message = "El id no puede ser menor que 0";
            }
            return result;

        }
        public ServiceResult<T> ValidacionesDelete<T>(ServiceResult<T> result, int id)
        {
            if (id <= 0)
            {
                result.Success = false;
                result.Message = "El id no puede ser menor que 0";
            }
            return result;

        }
    }
}
