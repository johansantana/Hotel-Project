
using Hotel.Aplication.Dtos.Categoria;

using Newtonsoft.Json;

using System.Text;

namespace Hotel.Web.HttpHelpper
{
    public class HttpHelper<TAdd, TUpdate> : IHttpHelper<TAdd,  TUpdate> 
        where TAdd : class
        where TUpdate : class
    {
        
        static readonly HttpClient httpClient;
        static HttpHelper()
        {
            HttpClientHandler httpClientHadler = new HttpClientHandler();
            httpClientHadler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
            httpClient = new HttpClient(httpClientHadler);

        }
        public async Task<string> DeleteAsync(string URL)
        {
            using (var response = await httpClient.DeleteAsync(URL))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await ResponderMensaje(response);

                }
                else
                {
                    return null;
                }
            }
           
        }

        public async Task<string> GetAsync(string URL)
        {

            using (var response = await httpClient.GetAsync(URL))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await ResponderMensaje(response);
                }
                else
                {
                    return null;
                }
            }
           
        }

        public async Task<string> GetAllAsync(string URL)
        {
            using (var response = await httpClient.GetAsync(URL))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await ResponderMensaje(response);
                }
                else
                {
                    return null;
                }
            }
            
        }

        public  async Task<string> PostAsync(string URL, TAdd AddDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(AddDto), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(URL, content))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await ResponderMensaje(response);

                }
                else
                {
                    return null;
                }
            }
           

        }

        public  async Task<string> PutAsync(string URL, TUpdate updateDto)
        {

            StringContent content = new StringContent(JsonConvert.SerializeObject(updateDto), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PutAsync(URL, content))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await ResponderMensaje(response);
                }
                else
                {
                    return null;
                }

            }




        }
        private async Task<string> ResponderMensaje(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");

            }
        }
    }




}
