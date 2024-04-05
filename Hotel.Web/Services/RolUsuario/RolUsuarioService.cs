using Hotel.Application.Dtos;
using Hotel.Infrastructure;
using Hotel.Web.Models.RolUsuario;
using System.Reflection;
using System.Text;
using System.Text.Json;
using Hotel.Web.Exceptions;

namespace Hotel.Web.Services.RolUsuario
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LoggerAdapter<RolUsuarioService> logger;
        private string? baseUrl;

        public RolUsuarioService(IConfiguration configuration,
            LoggerAdapter<RolUsuarioService> logger,
            IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
            string? hostName = configuration.GetValue<string>("HostName");
            string? port = configuration.GetValue<string>("Port");
            baseUrl = $"{hostName}/{port}";
        }

        public async Task<RolUsuarioListResult> Get()
        {
            try
            {
                var usuarios = new RolUsuarioListResult();

                string url = $"{baseUrl}/api/RolUsuario/GetRolUsuarios";
                using (HttpClient client = httpClientFactory.CreateClient())
                {
                    using (var response = await client.GetAsync(url))
                    {
                        usuarios = await HandleApiResponse<RolUsuarioListResult>(response);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new RolUsuarioServiceException("Error obteniendo los roles de usuario. " + ex.Message, logger);
            }
        }

        public async Task<RolUsuarioResult> GetById(int id)
        {
            try
            {
                var usuario = new RolUsuarioResult();

                string url = $"{baseUrl}/api/RolUsuario/GetRolUsuarioById?id={id}";
                using (HttpClient client = httpClientFactory.CreateClient())
                {
                    using (var response = await client.GetAsync(url))
                    {
                        usuario = await HandleApiResponse<RolUsuarioResult>(response);
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new RolUsuarioServiceException("Error obteniendo los roles de usuario. " + ex.Message, logger);
            }
        }

        public async Task<RolUsuarioResult> Save(RolUsuarioAddDto rolusuarioAddDto)
        {
            try
            {
                var usuario = new RolUsuarioResult();
                StringContent content = new StringContent(JsonSerializer.Serialize(rolusuarioAddDto), Encoding.UTF8, "application/json");

                string url = $"{baseUrl}/api/RolUsuario/AddRolUsuario";
                using (HttpClient client = httpClientFactory.CreateClient())
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        usuario = await HandleApiResponse<RolUsuarioResult>(response);
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new RolUsuarioServiceException("Error obteniendo los roles de usuario. " + ex.Message, logger);
            }
        }

        public async Task<RolUsuarioResult> Update(int id, RolUsuarioUpdateDto rolUsuarioUpdateDto)
        {
            try
            {
                var usuario = new RolUsuarioResult();

                StringContent content = new StringContent(JsonSerializer.Serialize(rolUsuarioUpdateDto), Encoding.UTF8, "application/json");
                string url = $"{baseUrl}/api/RolUsuario/UpdateRolUsuario?id={id}";

                using (HttpClient client = httpClientFactory.CreateClient())
                {
                    using (var response = await client.PutAsync(url, content))
                    {
                        usuario = await HandleApiResponse<RolUsuarioResult>(response);
                    }
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new RolUsuarioServiceException("Error obteniendo los roles de usuario. " + ex.Message, logger);
            }
        }

        public async Task<T> HandleApiResponse<T>(HttpResponseMessage response) where T : new()
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
