using Hotel.Web.Models;

namespace Hotel.Web.Core
{
    public interface IBaseService<TDeResult, TSingleResult, Tadd, TUpdate>
        where TDeResult : class
        where TSingleResult : class
        where Tadd : class
        where TUpdate : class
    {
        public TDeResult getAsync(string URL);
        public TSingleResult getAsyncOne(string URL);
        public TSingleResult post(string URL, Tadd AddDto);
        public TSingleResult put(string URL, TUpdate updateDto);
        public TSingleResult delete(string URL);
    }
}
