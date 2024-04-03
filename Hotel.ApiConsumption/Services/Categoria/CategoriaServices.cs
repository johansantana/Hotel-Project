using Hotel.Aplication.Dtos.Categoria;
using Hotel.ApiConsumption.Contracts.Categoria;

using Hotel.ApiConsumption.HttpHelpper;
using Hotel.ApiConsumption.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Hotel.Infrastructure.LoggerAdapter;
using Hotel.Domain;


namespace Hotel.Web.Services.Categoria
{
    public class CategoriaServices : ICategoriaServise
    {
        private readonly IHttpHelper<CategoriaAddDto, CategoriaUpdateDto> httpHelper;
        private readonly IConfiguration configuration;
        private readonly ILoggerAdapter<CategoriaServices> logger;
        private readonly string BaseUrl;
        public CategoriaServices(IHttpHelper<CategoriaAddDto, CategoriaUpdateDto> httpHelper, IConfiguration configuration
            , ILoggerAdapter<CategoriaServices> logger)
        {
            this.httpHelper = httpHelper;
            this.configuration = configuration;
            this.logger = logger;
            BaseUrl = configuration.GetSection("UrlConfig").GetSection("BaseUrl").Value;
        }


        // Hacer abstraccion tipo Aplicacion service para despues utilizar en el controller
        public CategoriaSingleResult delete(int id)
        {
            var categoria = new CategoriaSingleResult();
            try
            {
                var apiResponse = httpHelper.DeleteAsync($"{BaseUrl}/Categoria/DeleteCategoria?id={id}");

                categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

                if (!categoria.success)
                {
                    categoria.success = false;
                    categoria.message = "Error borrando la categoria ";
                    return categoria;
                }

                categoria.message = "Categoria borranda con exito  ";
            }
            catch (Exception ex)
            {
                categoria.success = false;
                categoria.message = "Error Borrando la categoria ";
                logger.LogError(categoria.message + ex.ToString());
            }

            return categoria;
        }



        public CategoriaDefaultResult getAsync()
        {
            var categoria = new CategoriaDefaultResult();
            try
            {
                var apiResponse = httpHelper.GetAllAsync($"{BaseUrl}/Categoria/GetCategoria");

                categoria = JsonConvert.DeserializeObject<CategoriaDefaultResult>(apiResponse.Result);

                if (!categoria.success)
                {
                    categoria.success = false;
                    categoria.message = "Error consiguiendo las categorias ";
                    return categoria;
                }
                categoria.message = "Categorias conseguidas con exito  ";
            }
            catch (Exception ex)
            {
                categoria.success = false;
                categoria.message = "Error consiguiendo las categorias ";
                logger.LogError(categoria.message + ex.ToString());
            }

            return categoria;
        }
        public CategoriaSingleResult getAsyncOne(int id)
        {
            var categoria = new CategoriaSingleResult();
            try
            {
                var apiResponse = httpHelper.GetAsync($"{BaseUrl}/Categoria/GetCategoriaById?id={id}");

                categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

                if (!categoria.success)
                {
                    categoria.success = false;
                    categoria.message = "Error consiguiendo la categoria ";
                    return categoria;
                }
                categoria.message = "Categoria conseguida con exito  ";
            }
            catch (Exception ex)
            {
                categoria.success = false;
                categoria.message = "Error consiguiendo la categoria ";
                logger.LogError(categoria.message + ex.ToString());
            }


            return categoria;
        }
        public CategoriaSingleResult post(CategoriaAddDto AddDto)
        {
            var categoria = new CategoriaSingleResult();
            try
            {
                var apiResponse = httpHelper.PostAsync($"{BaseUrl}/Categoria/SaveCategoria", AddDto);

                categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

                if (!categoria.success)
                {
                    categoria.success = false;
                    categoria.message = "Error guardando la categoria ";
                    return categoria;
                }
                categoria.message = "Categoria guardada con exito  ";
            }
            catch (Exception ex)
            {
                categoria.success = false;
                categoria.message = "Error guardando la categoria  ";
                logger.LogError(categoria.message + ex.ToString());
            }


            return categoria;
        }

        public CategoriaSingleResult put(CategoriaUpdateDto updateDto)
        {
            var categoria = new CategoriaSingleResult();
            try
            {
                var apiResponse = httpHelper.PutAsync($"{BaseUrl}/Categoria/UpdateCategoria", updateDto);

                categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse.Result);

                if (!categoria.success)
                {
                    categoria.success = false;
                    categoria.message = "Error actualizando la categoria ";
                    return categoria;
                }
                categoria.message = "Categoria actualizada con exito  ";

            }
            catch (Exception ex)
            {
                categoria.success = false;
                categoria.message = "Error actualizando la categoria ";
                logger.LogError(categoria.message + ex.ToString());
            }

            return categoria;

        }
    }
}
