using Hotel.Aplication.Dtos.Categoria;

namespace Hotel.ApiConsumption.HttpHelpper
{
    public interface IHttpHelper<TAdd, TUpdate> 
        where TAdd : class
        where TUpdate : class
    {
        public  Task<string> GetAllAsync(string URL);
        public Task<string> GetAsync(string URL);
        public Task<string> PostAsync(string URL, TAdd AddDto);
        public Task<string> PutAsync(string URL, TUpdate updateDto);
        public Task<string> DeleteAsync(string URL);
    }
}
