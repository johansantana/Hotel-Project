using Hotel.Application.Dtos;
using Hotel.Infrastructure;
using Hotel.Web.Models.Habitacion;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using Hotel.Web.Exceptions;

namespace Hotel.Web.Services.Habitacion
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LoggerAdapter<HabitacionService> logger;

        public HabitacionService(IHttpClientFactory httpClientFactory,
            LoggerAdapter<HabitacionService> logger)
        {
            this.logger = logger;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<HabitacionListResult> Get()
        {
            try
            {
                var habitaciones = new HabitacionListResult();

                string url = "/api/Habitacion/GetHabitaciones";
                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        habitaciones = await HandleApiResponse<HabitacionListResult>(response);
                    }
                }

                return habitaciones;
            }
            catch (Exception ex)
            {
                throw new HabitacionServiceException("Error obteniendo las habitaciones. " + ex.Message, logger);
            }
        }

        public async Task<HabitacionResult> GetById(int id)
        {
            try
            {
                var habitacion = new HabitacionResult();

                string url = $"/api/Habitacion/GetHabitacionById?id={id}";
                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.GetAsync(url))
                    {
                        habitacion = await HandleApiResponse<HabitacionResult>(response);
                    }
                }

                return habitacion;
            }
            catch (Exception ex)
            {
                throw new HabitacionServiceException("Error obteniendo la habitación. " + ex.Message, logger);
            }
        }

        public async Task<HabitacionResult> Save(HabitacionAddDto habitacionAddDto)
        {
            try
            {
                var habitacion = new HabitacionResult();
                StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionAddDto), Encoding.UTF8, "application/json");

                string url = $"/api/Habitacion/AddHabitacion";
                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        habitacion = await HandleApiResponse<HabitacionResult>(response);
                    }
                }

                return habitacion;
            }
            catch (Exception ex)
            {
                throw new HabitacionServiceException("Error obteniendo guardando la habitación. " + ex.Message, logger);
            }
        }

        public async Task<HabitacionResult> Update(int id, HabitacionUpdateDto habitacionUpdateDto)
        {
            try
            {
                var habitacion = new HabitacionResult();

                StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionUpdateDto), Encoding.UTF8, "application/json");
                string url = $"/api/Habitacion/UpdateHabitacion?id={id}";

                using (var httpClient = httpClientFactory.CreateClient("api"))
                {
                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        habitacion = await HandleApiResponse<HabitacionResult>(response);
                    }
                }

                return habitacion;
            }
            catch (Exception ex)
            {
                throw new HabitacionServiceException("Error actualizando la habitación. " + ex.Message, logger);
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
