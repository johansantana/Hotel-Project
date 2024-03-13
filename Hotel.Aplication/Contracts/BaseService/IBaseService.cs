using Hotel.Aplication.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Aplication.Contracts.BaseService
{
    public interface IBaseService<TEntityGet, TEntitySave ,TEntityUpdate, TEntityDelete> 
        where TEntityGet : class
        where TEntitySave : class
        where TEntityUpdate : class
        where TEntityDelete : class
    {
        ServiceResult<List<TEntityGet>> GetEntities();
        ServiceResult<TEntityGet> GetEntty(int id);

        ServiceResult<TEntitySave> SaveEntity(TEntitySave entiy);

        ServiceResult<TEntityUpdate> UpdateEntity(TEntityUpdate entiy);

        ServiceResult<TEntityDelete> DeleteEntity(int id);


    }
}
