using Hotel.Api.Core;
using Hotel.Api.Dtos.Recepcion;
using Hotel.Api.Models;

namespace Hotel.Api.Contract;

public interface IRecepcionService
{
ServiceResult<List<RecepcionGetModel>> GetRecepcions();
ServiceResult<RecepcionGetModel> GetRecepcion(int IdRecepcion);
ServiceResult<RecepcionGetModel> SaveRecepcion(RecepcionDto recepcionDtoDto);
ServiceResult<RecepcionGetModel> UpdateRecepcion(RecepcionDto recepcionDtoDto);
ServiceResult<RecepcionGetModel> RemoveCategory(RecepcionDto recepcionDtoDto);

}