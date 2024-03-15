

using Hotel.Aplication.Core;
using Hotel.Aplication.Dtos.Categoria;
using Hotel.Aplication.Exceptions.Categoria;
using Hotel.Aplication.Service;
using Hotel.Infrastructure.LoggerAdapter;

namespace Hotel.Aplication.Exceptions.Validaciones
{
    public class CategoriaValidaciones
    {
        public LoggerAdapter<CategoriaService> logger { get; set; }
        public CategoriaValidaciones(LoggerAdapter<CategoriaService> logger )
        {
            this.logger = logger;
        }

        public bool ValidacionesAdd<T>(ServiceResult<T> result, CategoriaAddDto categoria)
        {   
            if (string.IsNullOrEmpty(categoria.Descripcion))
            {
            result.Success = false;
            result.Message = "La descripcion no puede estar vacia";
             throw new CategoriaServiceException(result.Message, logger);
            }
            return result.Success;
        }
        public bool  ValidacionesUpdate<T>( ServiceResult<T> result, CategoriaUpdateDto categoria)
        {
            if (string.IsNullOrEmpty(categoria.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion no puede estar vacia";
                throw new CategoriaServiceException(result.Message, logger);
            }
            if (categoria.IdCategoria <= 0)
            {
                result.Success = false;
                result.Message = "El id no puede ser menor que 0";
                throw new CategoriaServiceException(result.Message, logger);
            }
            return result.Success;

        }
        public bool ValidacionesDelete<T>(ServiceResult<T> result, int id)
        {
            if (id <= 0)
            {
                result.Success = false;
                result.Message = "El id no puede ser menor que 0";
                throw new CategoriaServiceException(result.Message, logger);
            }
            return result.Success;

        }
    }
}
