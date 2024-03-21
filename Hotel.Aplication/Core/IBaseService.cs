using Hotel.Aplication.Core;

namespace Hotel.Aplication.Contracts.BaseService
{
    public interface IBaseService<TEntityModel, TEntitySave ,TEntityUpdate> 
        where TEntityModel : class
        where TEntitySave : class
        where TEntityUpdate : class
    {
        ServiceResult<List<TEntityModel>> GetEntities();
        ServiceResult<TEntityModel> GetEntity(int id);

        ServiceResult<TEntityModel> SaveEntity(TEntitySave entiy);

        ServiceResult<TEntityModel> UpdateEntity(TEntityUpdate entiy);

        ServiceResult<TEntityModel> DeleteEntity(int id);


    }
}
