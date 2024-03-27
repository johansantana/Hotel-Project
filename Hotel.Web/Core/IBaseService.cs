using Hotel.Web.Models;

namespace Hotel.Web.Core
{
    public interface IBaseService<TDeResult, TSingleResult, Tadd, TUpdate>
        where TDeResult : class
        where TSingleResult : class
        where Tadd : class
        where TUpdate : class
    {
        public TDeResult getAsync();
        public TSingleResult getAsyncOne(int id);
        public TSingleResult post(Tadd AddDto);
        public TSingleResult put(TUpdate updateDto);
        public TSingleResult delete(int id);
    }
}
