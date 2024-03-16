using Hotel.Application.Core;

namespace Hotel.Application.Contracts;

public interface IBaseService<TGetData, TSaveData, TUpdateData, TDeleteData>
    where TGetData : class
    where TSaveData : class
    where TUpdateData : class
    where TDeleteData : class
{
    ServiceResult<List<TGetData>> Get();
    ServiceResult<TGetData> GetById(int id);
    ServiceResult<TSaveData> Save(TSaveData data);
    ServiceResult<TUpdateData> Update(int id, TUpdateData data);
    ServiceResult<TDeleteData> Delete(int id);
}