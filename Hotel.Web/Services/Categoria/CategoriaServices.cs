using Hotel.Aplication.Dtos.Categoria;
using Hotel.Web.Contracts.Categoria;
using Hotel.Web.HttpHelpper;
using Hotel.Web.Models;
using Newtonsoft.Json;


namespace Hotel.Web.Services.Categoria
{
    public class CategoriaServices : ICategoriaServise
    {
        private readonly IHttpHelper<CategoriaAddDto, CategoriaUpdateDto> httpHelper;
        public CategoriaServices(IHttpHelper<CategoriaAddDto, CategoriaUpdateDto>  httpHelper)
        {
            this.httpHelper = httpHelper;
            
        }
        // Hacer abstraccion tipo Aplicacion service para despues utilizar en el controller
        public  CategoriaSingleResult delete(string URL)
        {
           

            var apiResponse = httpHelper.DeleteAsync(URL);
            var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);
            if (!categoria.success)
            {
                categoria.success = false;
                return categoria;
            }

            return categoria;
        }



        public  CategoriaDefaultResult getAsync(string URL)
        {
           
            var apiResponse = httpHelper.GetAllAsync(URL);

            var categoria = JsonConvert.DeserializeObject<CategoriaDefaultResult>(apiResponse.Result);
            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;
        }
        public  CategoriaSingleResult getAsyncOne(string URL)
        {
            
            var apiResponse = httpHelper.GetAsync(URL);

            var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);
            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;
        }
        public  CategoriaSingleResult post(string URL, CategoriaAddDto AddDto)
        {
           
            var apiResponse = httpHelper.PostAsync(URL, AddDto);

            var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);
            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;
        }

        public  CategoriaSingleResult put(string URL, CategoriaUpdateDto updateDto)
        {
            
            var apiResponse = httpHelper.PutAsync(URL, updateDto);

           var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);
            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;

        }
    }
}
