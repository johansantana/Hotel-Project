using Hotel.Application.Dtos;
using Hotel.Web.Models.Usuario;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Hotel.Web.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient httpClient;
        private readonly HttpClientHandler httpClientHandler;

        public UsuarioService()
        {
            this.httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyError) => { return true; };
            httpClient = new HttpClient(httpClientHandler);
        }

        public async Task<UsuarioListResult> Get()
        {
            var usuarios = new UsuarioListResult();

            string url = "http://localhost:5202/api/Usuario/GetUsuarios";
            using (var response = await httpClient.GetAsync(url))
            {
                usuarios = await HandleApiResponse<UsuarioListResult>(response);
            }

            return usuarios;
        }

        public async Task<UsuarioResult> GetById(int id)
        {
            var usuario = new UsuarioResult();

            string url = $"http://localhost:5202/api/Usuario/GetUsuarioById?id={id}";
            using (var response = await httpClient.GetAsync(url))
            {
                usuario = await HandleApiResponse<UsuarioResult>(response);
            }

            return usuario;
        }

        public async Task<UsuarioResult> Save(UsuarioAddDto usuarioAddDto)
        {
            var usuario = new UsuarioResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(usuarioAddDto), Encoding.UTF8, "application/json");

            string url = $"http://localhost:5202/api/Usuario/AddUsuario";
            using (var response = await httpClient.PostAsync(url, content))
            {
                usuario = await HandleApiResponse<UsuarioResult>(response);
            }

            return usuario;
        }

        public async Task<UsuarioResult> Update(int id, UsuarioUpdateDto usuarioUpdateDto)
        {
            var usuario = new UsuarioResult();

            StringContent content = new StringContent(JsonConvert.SerializeObject(usuarioUpdateDto), Encoding.UTF8, "application/json");
            string url = $"http://localhost:5202/api/Usuario/UpdateUsuario?id={id}";

            using (var response = await httpClient.PutAsync(url, content))
            {
                usuario = await HandleApiResponse<UsuarioResult>(response);
            }

            return usuario;
        }

        private async Task<T> HandleApiResponse<T>(HttpResponseMessage response) where T : new()
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
