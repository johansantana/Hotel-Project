using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Core;
using Hotel.Aplication.Dtos.Categoria;
using Hotel.Aplication.Exceptions.Categoria;
using Hotel.Aplication.Models.Categoria;
using Hotel.Domain;
using Hotel.Infrastructure.LoggerAdapter;



namespace Hotel.Aplication.Service
{
    public class CategoriaService : ICategoriaService
    {

         public ILoggerAdapter<CategoriaService> _logger {  get; set; }
        public ICategoriaRepository categoriaRepository { get; set; }
        public CategoriaService(ILoggerAdapter<CategoriaService> logger, ICategoriaRepository categoriaRe) 
        {

            _logger = logger;
            categoriaRepository = categoriaRe;
        }

        public  ServiceResult<CategoriaGetModel> DeleteEntity(int id)
        {
            ServiceResult<CategoriaGetModel> result = new ServiceResult<CategoriaGetModel>();
            try {
                //Validaciones
                //id no nulo
                var idValid = ValidID( id);

                if (!idValid.Success)
                {
                    result.Success = idValid.Success;
                    result.Message =  idValid.Message;
                    return result;
                }
                var categoriaDeleted = categoriaRepository.GetEntity(id);
                this.categoriaRepository.Remove(categoriaDeleted);
                result.Message = "categoria Eliminada con exito";

            }
            catch (Exception ex){
                result.Success = false;
                result.Message = "Error borrando la categoria";
               throw new CategoriaServiceException(result.Message + ex.ToString(), _logger);
            }

            return result;
        }

        public  ServiceResult<List<CategoriaGetModel>> GetEntities()
        {
            ServiceResult<List<CategoriaGetModel>> result = new ServiceResult<List<CategoriaGetModel>>();
            try
            {
                result.Data = this.categoriaRepository.GetEntities().Select(cd => new CategoriaGetModel() 
                {
                    IdCategoria = cd.IdCategoria,
                    Descripcion = cd.Descripcion,
                    Estado = cd.Estado,
                    FechaCreacion = cd.FechaCreacion,

                }).ToList();
                result.Message = "categorias recuperadas con exito";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorias";
                //_Logger.LogError(result.Message + ex.ToString());
               throw new CategoriaServiceException(result.Message + ex.ToString(), _logger);
            }
            
            return result;
        }

        public  ServiceResult<CategoriaGetModel> GetEntity(int id)
        {
            ServiceResult<CategoriaGetModel> result = new ServiceResult<CategoriaGetModel>();
            try {
                var categoria = this.categoriaRepository.GetEntity(id);
                result.Data = new CategoriaGetModel()
                {
                    IdCategoria = categoria.IdCategoria,
                    Descripcion = categoria.Descripcion,
                    Estado = categoria.Estado,
                    FechaCreacion = categoria.FechaCreacion,
                };
                result.Message = "categoria recuperada con exito con exito";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la categoria";
                throw new CategoriaServiceException(result.Message + ex.ToString(), _logger);

            }
            return result;
        }

        public ServiceResult<CategoriaGetModel> SaveEntity(CategoriaAddDto categoriaAddDto)
        {
            ServiceResult<CategoriaGetModel> result = new ServiceResult<CategoriaGetModel>();
            try {
                var resultIsValid = IsValid(categoriaAddDto);

                
                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;
                    return result;
                }

                    this.categoriaRepository.Add(new Categoria()
                {
                    Estado = categoriaAddDto.Estado,
                    Descripcion = categoriaAddDto.Descripcion,
                    FechaCreacion = categoriaAddDto.FechaCreacion
                });

                result.Message = "categoria guardada con exito";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoria";
                throw new CategoriaServiceException(result.Message + ex.ToString(), _logger);
            }
            return result;
        }

        public  ServiceResult<CategoriaGetModel> UpdateEntity(CategoriaUpdateDto categoriaUpdateDto)
        {
            ServiceResult<CategoriaGetModel> result = new ServiceResult<CategoriaGetModel>();

            try
            {
                var resultIsValid = IsValid(categoriaUpdateDto);
                var idValid = ValidID(categoriaUpdateDto.IdCategoria);
                
                if (!resultIsValid.Success || !idValid.Success)
                {
                    result.Success = !resultIsValid.Success ? resultIsValid.Success : idValid.Success;
                    result.Message = !resultIsValid.Success? resultIsValid.Message : idValid.Message;
                    return result;
                }

                this.categoriaRepository.Update(new Categoria()
                {
                    IdCategoria = categoriaUpdateDto.IdCategoria,
                    Descripcion = categoriaUpdateDto.Descripcion,
                    Estado = categoriaUpdateDto.Estado,

                });
                result.Message = "categoria actualizada con exito";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la categoria";
                throw new CategoriaServiceException(result.Message + ex.ToString(), _logger);
            }
            return result;
        }

        private ServiceResult<string> IsValid(CategoriaDtoBase categoriaDtoBase)
        {
            ServiceResult<string> result = new ServiceResult<string>();
            if (string.IsNullOrEmpty(categoriaDtoBase.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion no puede estar vacia";
                _logger.LogWarning(result.Message);
                return result;
            }
            if (categoriaDtoBase.Descripcion.Length > 200)
            {
                result.Success = false;
                result.Message = "La descripcion no puede estar vacia";
                _logger.LogWarning(result.Message);
                return result;
            }
            return result;
        }

        private ServiceResult<int> ValidID( int id)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            if (!categoriaRepository.Exists(cd => cd.IdCategoria == id))
            {
                result.Success = false;
                result.Message = "La categoria no existe";
                _logger.LogWarning(result.Message);
                return result;
            }
            return result;
        }


    }
}
