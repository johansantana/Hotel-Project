using Hotel.Application.Dtos;
using Hotel.Web.Exceptions;
using Hotel.Infrastructure;
using Hotel.Web.Models.Usuario;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Net.Http;

namespace Hotel.Web.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LoggerAdapter<UsuarioService> logger;
        private string? baseUrl;

        public UsuarioService(IConfiguration configuration, 
            IHttpClientFactory httpClientFactory,
            LoggerAdapter<UsuarioService> logger)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            string? hostName = configuration.GetValue<string>("HostName");
            string? port = configuration.GetValue<string>("Port");
            baseUrl = $"{hostName}/{port}";

        }

        public async Task<UsuarioListResult> Get()
        {
            try
            {
                var usuarios = new UsuarioListResult();

                string url = $"{baseUrl}/api/Usuario/GetUsuarios";

                using (var client = httpClientFactory.CreateClient())
                {
                    using (var response = await client.GetAsync(url))
                    {
                        usuarios = await HandleApiResponse<UsuarioListResult>(response);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new UsuarioServiceException("Error obteniendo los usuarios. " + ex.Message, logger);
            }
        }

        public async Task<UsuarioResult> GetById(int id)
        {
            try
            {
                var usuario = new UsuarioResult();

                string url = $"{baseUrl}/api/Usuario/GetUsuarioById?id={id}";
                using (HttpClient client = httpClientFactory.CreateClient("httphandler"))
                {
                    using (var response = await client.GetAsync(url))
                    {
                        usuario = await HandleApiResponse<UsuarioResult>(response);
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new UsuarioServiceException("Error obteniendo el usuario. " + ex.Message, logger);
            }
        }

        public async Task<UsuarioResult> Save(UsuarioAddDto usuarioAddDto)
        {
            try
            {
                var usuario = new UsuarioResult();
                StringContent content = new StringContent(JsonSerializer.Serialize(usuarioAddDto), Encoding.UTF8, "application/json");

                string url = $"{baseUrl}/api/Usuario/AddUsuario";
                using (HttpClient client = httpClientFactory.CreateClient("httphandler"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        usuario = await HandleApiResponse<UsuarioResult>(response);
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new UsuarioServiceException("Error guardando el usuario. " + ex.Message, logger);
            }
        }

        public async Task<UsuarioResult> Update(int id, UsuarioUpdateDto usuarioUpdateDto)
        {
            try
            {
                var usuario = new UsuarioResult();

                StringContent content = new StringContent(JsonSerializer.Serialize(usuarioUpdateDto), Encoding.UTF8, "application/json");
                string url = $"{baseUrl}/api/Usuario/UpdateUsuario?id={id}";

                using (HttpClient client = httpClientFactory.CreateClient("httphandler"))
                {
                    using (var response = await client.PutAsync(url, content))
                    {
                        usuario = await HandleApiResponse<UsuarioResult>(response);
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new UsuarioServiceException("Error Actualizando el usuario. " + ex.Message, logger);
            }
        }

        private async Task<T> HandleApiResponse<T>(HttpResponseMessage response) where T : new()
        {
            T? result = new T();

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<T>(apiResponse);
            }
            else
            {
                PropertyInfo? successProperty = typeof(T).GetProperty("success");
                PropertyInfo? messageProperty = typeof(T).GetProperty("message");

                if (successProperty != null)
                {
                    successProperty.SetValue(result, false);
                }

                if (messageProperty != null)
                {
                    messageProperty.SetValue(result, "Error al conectar con la API de usuarios.");
                }
            }

            return result ?? new T();
        }
    }
}
