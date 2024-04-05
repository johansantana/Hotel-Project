using Hotel.Application.Dtos;
using Hotel.Web.Models.EstadoHabitacion;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using Hotel.Web.Exceptions;
using System.Net.Http;
using Hotel.Infrastructure;

namespace Hotel.Web.Services.EstadoHabitacion
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LoggerAdapter<EstadoHabitacionService> logger;

        public EstadoHabitacionService(IHttpClientFactory httpClientFactory,
            LoggerAdapter<EstadoHabitacionService> logger)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<EstadoHabitacionListResult> Get()
        {
            try
            {
                var estadosHabitacion = new EstadoHabitacionListResult();

                string url = "/api/EstadoHabitacion/GetEstadoHabitaciones";

                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        estadosHabitacion = await HandleApiResponse<EstadoHabitacionListResult>(response);
                    }
                }

                return estadosHabitacion;
            }
            catch (Exception ex)
            {
                throw new EstadoHabitacionServiceException("Error obteniendo los estados de habitación. " + ex.Message, logger);
            }
        }

        public async Task<EstadoHabitacionResult> GetById(int id)
        {
            try
            {
                var estadoHabitacion = new EstadoHabitacionResult();

                string url = $"/api/EstadoHabitacion/GetEstadoHabitacionById?id={id}";
                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        estadoHabitacion = await HandleApiResponse<EstadoHabitacionResult>(response);
                    }
                }

                return estadoHabitacion;
            }
            catch (Exception ex)
            {
                throw new EstadoHabitacionServiceException("Error obteniendo el estado de habitación. " + ex.Message, logger);
            }
        }

        public async Task<EstadoHabitacionResult> Save(EstadoHabitacionAddDto estadoHabitacionAddDto)
        {
            try
            {
                var estadoHabitacion = new EstadoHabitacionResult();
                StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionAddDto), Encoding.UTF8, "application/json");

                string url = $"/api/EstadoHabitacion/AddEstadoHabitacion";
                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        estadoHabitacion = await HandleApiResponse<EstadoHabitacionResult>(response);
                    }
                }

                return estadoHabitacion;
            }
            catch (Exception ex)
            {
                throw new EstadoHabitacionServiceException("Error guardando el estado de habitación. " + ex.Message, logger);
            }
        }

        public async Task<EstadoHabitacionResult> Update(int id, EstadoHabitacionUpdateDto estadoHabitacionUpdateDto)
        {
            try
            {
                var estadoHabitacion = new EstadoHabitacionResult();

                StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionUpdateDto), Encoding.UTF8, "application/json");
                string url = $"/EstadoHabitacion/UpdateEstadoHabitacion?id={id}";

                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        estadoHabitacion = await HandleApiResponse<EstadoHabitacionResult>(response);
                    }
                }

                return estadoHabitacion;
            }
            catch (Exception ex)
            {
                throw new EstadoHabitacionServiceException("Error actualizando el estado de habitación. " + ex.Message, logger);
            }
        }

        private async Task<T> HandleApiResponse<T>(HttpResponseMessage response) where T : new()
        {
            T? result = new T();

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(apiResponse);
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
