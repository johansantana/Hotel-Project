using Hotel.Application.Dtos;
using Hotel.Web.Models.RolUsuario;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Hotel.Web.Services.RolUsuario
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly HttpClient httpClient;
        private readonly HttpClientHandler httpClientHandler;

        public RolUsuarioService()
        {
            this.httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyError) => { return true; };
            httpClient = new HttpClient(httpClientHandler);
        }

        public async Task<RolUsuarioListResult> Get()
        {
            var usuarios = new RolUsuarioListResult();

            string url = "http://localhost:5202/api/RolUsuario/GetRolUsuarios";
            using (var response = await httpClient.GetAsync(url))
            {
                usuarios = await HandleApiResponse<RolUsuarioListResult>(response);
            }

            return usuarios;
        }

        public async Task<RolUsuarioResult> GetById(int id)
        {
            var usuario = new RolUsuarioResult();

            string url = $"http://localhost:5202/api/RolUsuario/GetRolUsuarioById?id={id}";
            using (var response = await httpClient.GetAsync(url))
            {
                usuario = await HandleApiResponse<RolUsuarioResult>(response);
            }

            return usuario;
        }

        public async Task<RolUsuarioResult> Save(RolUsuarioAddDto rolusuarioAddDto)
        {
            var usuario = new RolUsuarioResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(rolusuarioAddDto), Encoding.UTF8, "application/json");

            string url = $"http://localhost:5202/api/RolUsuario/AddRolUsuario";
            using (var response = await httpClient.PostAsync(url, content))
            {
                usuario = await HandleApiResponse<RolUsuarioResult>(response);
            }

            return usuario;
        }

        public async Task<RolUsuarioResult> Update(int id, RolUsuarioUpdateDto rolUsuarioUpdateDto)
        {
            var usuario = new RolUsuarioResult();

            StringContent content = new StringContent(JsonConvert.SerializeObject(rolUsuarioUpdateDto), Encoding.UTF8, "application/json");
            string url = $"http://localhost:5202/api/RolUsuario/UpdateRolUsuario?id={id}";

            using (var response = await httpClient.PutAsync(url, content))
            {
                usuario = await HandleApiResponse<RolUsuarioResult>(response);
            }

            return usuario;
        }

        public async Task<T> HandleApiResponse<T>(HttpResponseMessage response) where T : new()
        {
            T result = new T();

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(apiResponse);
            }
            else
            {
                PropertyInfo successProperty = typeof(T).GetProperty("success");
                PropertyInfo messageProperty = typeof(T).GetProperty("message");

                if (successProperty != null)
                {
                    successProperty.SetValue(result, false);
                }

                if (messageProperty != null)
                {
                    messageProperty.SetValue(result, "Error al conectar con la API de usuarios.");
                }
            }

            return result;
        }
    }
}
