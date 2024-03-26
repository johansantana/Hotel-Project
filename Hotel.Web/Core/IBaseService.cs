using Hotel.Web.Models;

namespace Hotel.Web.Core
{
    public interface IBaseService<TDeResult, TSingleResult, Tadd, TUpdate>
        where TDeResult : class
        where TSingleResult : class
        where Tadd : class
        where TUpdate : class
    {
        public Task<TDeResult> getAsync(string URL);
        public Task<TSingleResult> getAsyncOne(string URL);
        public void post(string URL, Tadd AddDto);
        public void put(string URL, TUpdate updateDto);
        public void delete(string URL);
    }
}
