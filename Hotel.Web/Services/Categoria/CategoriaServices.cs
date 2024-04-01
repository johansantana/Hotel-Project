using Hotel.Aplication.Dtos.Categoria;
using Hotel.Web.Contracts.Categoria;
using Hotel.Web.EndpoitComponent.Categoria;
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
        public  CategoriaSingleResult delete(int id)
        {
           

            var apiResponse = httpHelper.DeleteAsync(CategoriasEnpointsGetter.EnpointDelete(id));

            var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

            if (!categoria.success)
            {
                categoria.success = false;
                return categoria;
            }

            return categoria;
        }



        public  CategoriaDefaultResult getAsync()
        {
            var apiResponse = httpHelper.GetAllAsync(CategoriasEnpointsGetter.EnpointGetAll());

            var categoria = JsonConvert.DeserializeObject<CategoriaDefaultResult>(apiResponse.Result);

            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;
        }
        public  CategoriaSingleResult getAsyncOne(int id)
        {
            
            var apiResponse = httpHelper.GetAsync(CategoriasEnpointsGetter.EnpointGet(id));

            var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;
        }
        public  CategoriaSingleResult post(CategoriaAddDto AddDto)
        {
           
            var apiResponse = httpHelper.PostAsync(CategoriasEnpointsGetter.EnpointPost(), AddDto);

            var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;
        }

        public  CategoriaSingleResult put(CategoriaUpdateDto updateDto)
        {
            
            var apiResponse = httpHelper.PutAsync(CategoriasEnpointsGetter.EnpointUpdate(), updateDto);

           var categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

            if (!categoria.success)
            {

                return categoria;
            }

            return categoria;

        }
    }
}
