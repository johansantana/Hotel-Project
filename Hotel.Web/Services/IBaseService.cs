namespace Hotel.Web.Services
{
    public interface IBaseService<TListResult, TResult, TAdd, TUpdate>
    {
        Task<TListResult> Get();
        Task<TResult> GetById(int id);
        Task<TResult> Save(TAdd add);
        Task<TResult> Update(int id, TUpdate update);
    }
}
