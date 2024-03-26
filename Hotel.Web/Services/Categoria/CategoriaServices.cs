using Hotel.Aplication.Dtos.Categoria;
using Hotel.Aplication.Models.Categoria;
using Hotel.Web.Contracts.Categoria;
using Hotel.Web.Core;
using Hotel.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.Web.Services.Categoria
{
    public class CategoriaServices : ICategoriaServise
    {
        HttpClientHandler httpClientHadler = new HttpClientHandler();
        public CategoriaServices()
        {
            this.httpClientHadler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }
        // Hacer abstraccion tipo Aplicacion service para despues utilizar en el controller
        public async Task<CategoriaSingleResult> delete(string URL)
        {
            var categoria = new CategoriaSingleResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {
                using (var response = await httpClient.DeleteAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        if (!categoria.success)
                        {
                            categoria.success = false;
                            return categoria;
                        }
                        //categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        //if (!categoria.success)
                        //{
                        //    ViewBag.Message = categoria.message;
                        //    return View();
                        //}
                    }
                }
            }
            return categoria;
        }



        public async Task<CategoriaDefaultResult> getAsync(string URL)
        {
            var categoria = new CategoriaDefaultResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {

                using (var response = await httpClient.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaDefaultResult>(apiResponse);
                        if (!categoria.success)
                        {

                            return categoria;
                        }
                    }
                }
            }
            return categoria;
        }
        public async Task<CategoriaSingleResult> getAsyncOne(string URL)
        {
            var categoria = new CategoriaSingleResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {


                using (var response = await httpClient.GetAsync(URL))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject <CategoriaSingleResult> (apiResponse);
                        if (!categoria.success)
                        {
                            return categoria;
                        }

                    }
                }
            }
            return categoria;
        }
        public async Task<CategoriaSingleResult> post(string URL, CategoriaAddDto AddDto)
        {
            var categoria = new CategoriaSingleResult();

            using (var httpClient = new HttpClient(this.httpClientHadler))
            {

                AddDto.FechaCreacion = DateTime.Now;
                StringContent content = new StringContent(JsonConvert.SerializeObject(AddDto), Encoding.UTF8, "application/json");
               
                using (var response = await httpClient.PostAsync(URL, content))
                {

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        if (!categoria.success)
                        {
                            categoria.success = false;
                            return categoria;
                        }



                    }
                }
            }
            return categoria;
        }

        public async Task<CategoriaSingleResult> put(string URL, CategoriaUpdateDto updateDto)
        {
            var categoria = new CategoriaSingleResult();
            using (var httpClient = new HttpClient(this.httpClientHadler))
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(updateDto), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(URL, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categoria = JsonConvert.DeserializeObject<CategoriaSingleResult>(apiResponse);
                        if (!categoria.success)
                        {
                            categoria.success = false;
                            return categoria;
                        }

                    }
                }
            }

            return categoria;

        }
    }
}
