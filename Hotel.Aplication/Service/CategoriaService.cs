using Hotel.Aplication.Contracts;
using Hotel.Aplication.Core;
using Hotel.Aplication.Dtos.Categoria;
using Hotel.Aplication.Models.Categoria;
using Hotel.Domain;
using Microsoft.Extensions.Logging;


namespace Hotel.Aplication.Service
{
    public class CategoriaService : ICategoriaService
    {
        public ILogger<CategoriaService> Logger { get; set; }  //Hacer abstraccion (Patron adapter)
        public ICategoriaRepository categoriaRepository { get; set; }
        public CategoriaService(ILogger<CategoriaService> logger, ICategoriaRepository categoriaRe) 
        {
       
            Logger = logger;
            categoriaRepository = categoriaRe;
        }
        //Cambiar CategoriaDeletedDto
        public ServiceResult<CategoriaDeleteDto> DeleteEntity(int id)
        {
            ServiceResult<CategoriaDeleteDto> result = new ServiceResult<CategoriaDeleteDto>();
            try {

                var categoriaDeleted = categoriaRepository.GetEntity(id);
                this.categoriaRepository.Remove(categoriaDeleted);

            }
            catch (Exception ex){
                result.Success = false;
                result.Message = "Error borrando la categoria";
                this.Logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<List<CategoriaGetModel>> GetEntities()
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
                this.Logger.LogError(result.Message, ex.ToString());
            }
            
            return result;
        }

        public ServiceResult<CategoriaGetModel> GetEntty(int id)
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
                this.Logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult<CategoriaAddDto> SaveEntity(CategoriaAddDto categoriaAddDto)
        {
            ServiceResult<CategoriaAddDto> result = new ServiceResult<CategoriaAddDto>();
            try {
                //Hacer validaciones

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
                this.Logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<CategoriaUpdateDto> UpdateEntity(CategoriaUpdateDto categoriaUpdateDto)
        {
            ServiceResult<CategoriaUpdateDto> result = new ServiceResult<CategoriaUpdateDto>();

            //hacer validaciones
            try {
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
                this.Logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
