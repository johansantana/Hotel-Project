using System.Linq.Expressions;
using Hotel.Api.Contract;
using Hotel.Api.Core;
using Hotel.Api.Dtos.Recepcion;
using Hotel.Api.Models;

namespace Hotel.Api.Service 
{
    public class RecepcionService : IRecepcionService
    {
        public RecepcionService(ILogger
        {

        }
        public ServiceResult<RecepcionGetModel> GetRecepcion(int IdRecepcion)
        {
            ServiceResult<List<RecepcionGetModel>> result = new ServiceResult<List<RecepcionGetModel>>();

            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public ServiceResult<List<RecepcionGetModel>> GetRecepcions()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<RecepcionGetModel> RemoveCategory(RecepcionDto recepcionDtoDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<RecepcionGetModel> SaveRecepcion(RecepcionDto recepcionDtoDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<RecepcionGetModel> UpdateRecepcion(RecepcionDto recepcionDtoDto)
        {
            throw new NotImplementedException();
        }
    }
}