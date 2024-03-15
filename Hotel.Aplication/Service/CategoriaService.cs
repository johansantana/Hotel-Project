using Hotel.Aplication.Contracts.Categoria;
using Hotel.Aplication.Core;
using Hotel.Aplication.Dtos.Categoria;
using Hotel.Aplication.Exceptions.Categoria;
using Hotel.Aplication.Exceptions.Validaciones;
using Hotel.Aplication.Models.Categoria;
using Hotel.Domain;
using Hotel.Infrastructure.LoggerAdapter;



namespace Hotel.Aplication.Service
{
    public class CategoriaService : ICategoriaService
    {
        public LoggerAdapter<CategoriaService> _Logger { get; set; }  //Hacer abstraccion (Patron adapter)
        public ICategoriaRepository categoriaRepository { get; set; }
        public CategoriaValidaciones categoriaValidaciones { get; set; }
        public CategoriaService(LoggerAdapter<CategoriaService> logger, ICategoriaRepository categoriaRe) 
        {
       
            _Logger = logger;
            categoriaRepository = categoriaRe;
            this.categoriaValidaciones = new CategoriaValidaciones(_Logger);
        }
        //Cambiar CategoriaDeletedDto
        public  ServiceResult<CategoriaDeleteDto> DeleteEntity(int id)
        {
            ServiceResult<CategoriaDeleteDto> result = new ServiceResult<CategoriaDeleteDto>();
            try {
                //Validaciones
                //id no nulo
                categoriaValidaciones.ValidacionesDelete(result, id);
                if (!result.Success)
                {
                    return result;
                }

                var categoriaDeleted = categoriaRepository.GetEntity(id);
                this.categoriaRepository.Remove(categoriaDeleted);

            }
            catch (Exception ex){
                result.Success = false;
                result.Message = "Error borrando la categoria";
               // this._Logger.LogError(result.Message );
                //return result;
              throw new CategoriaServiceException(result.Message + ex.ToString(), _Logger);
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
            }catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorias";
                //_Logger.LogError(result.Message + ex.ToString());
                throw new CategoriaServiceException(result.Message + ex.ToString(), _Logger);
            }
            
            return result;
        }

        public  ServiceResult<CategoriaGetModel> GetEntty(int id)
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
              
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la categoria";
                //_Logger.LogError(result.Message + ex.ToString());
                throw new CategoriaServiceException(result.Message + ex.ToString(), _Logger);

            }
            return result;
        }

        public  ServiceResult<CategoriaAddDto> SaveEntity(CategoriaAddDto categoriaAddDto)
        {
            ServiceResult<CategoriaAddDto> result = new ServiceResult<CategoriaAddDto>();
            try {
                //Hacer validaciones
                //Validaciones
                //Descripcion no nulo
                categoriaValidaciones.ValidacionesAdd(result, categoriaAddDto);
                if (!result.Success)
                {
                    return result;
                }


                this.categoriaRepository.Add(new Categoria()
                {
                    Estado = categoriaAddDto.Estado,
                    Descripcion = categoriaAddDto.Descripcion,
                    FechaCreacion = categoriaAddDto.FechaCreacion
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoria";
                //_Logger.LogError(result.Message + ex.ToString());
                throw new CategoriaServiceException(result.Message + ex.ToString(), _Logger);
            }
            return result;
        }

        public  ServiceResult<CategoriaUpdateDto> UpdateEntity(CategoriaUpdateDto categoriaUpdateDto)
        {
            ServiceResult<CategoriaUpdateDto> result = new ServiceResult<CategoriaUpdateDto>();

            //hacer validaciones
            //Validaciones
            //id no nulo
            //Deccripcion no nulo
            try
            {
                categoriaValidaciones.ValidacionesUpdate(result, categoriaUpdateDto);
                if (!result.Success)
                {
                    return result;
                }

                this.categoriaRepository.Update(new Categoria()
                {
                    IdCategoria = categoriaUpdateDto.IdCategoria,
                    Descripcion = categoriaUpdateDto.Descripcion,
                    Estado = categoriaUpdateDto.Estado,

                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la categoria";
                //_Logger.LogError(result.Message + ex.ToString());
                throw new CategoriaServiceException(result.Message + ex.ToString(), _Logger );
            }
            return result;
        }


    }
}
