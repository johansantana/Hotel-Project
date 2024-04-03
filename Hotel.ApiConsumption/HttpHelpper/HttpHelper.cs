

using Newtonsoft.Json;

using System.Text;

namespace Hotel.ApiConsumption.HttpHelpper
{
    public class HttpHelper<TAdd, TUpdate> : IHttpHelper<TAdd, TUpdate>
        where TAdd : class
        where TUpdate : class
    {
        private readonly IHttpClientFactory clientFactory;


        public HttpHelper(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;

        }
        public async Task<string> DeleteAsync(string URL)
        {
            using (var httpClient = clientFactory.CreateClient())
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


        }

        public async Task<string> GetAsync(string URL)
        {
            using (var httpClient = clientFactory.CreateClient())
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

        }

        public async Task<string> GetAllAsync(string URL)
        {
            using (var httpClient = clientFactory.CreateClient())
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


        }

        public async Task<string> PostAsync(string URL, TAdd AddDto)
        {
            using (var httpClient = clientFactory.CreateClient())
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


        }

        public async Task<string> PutAsync(string URL, TUpdate updateDto)
        {
            using (var httpClient = clientFactory.CreateClient())
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
