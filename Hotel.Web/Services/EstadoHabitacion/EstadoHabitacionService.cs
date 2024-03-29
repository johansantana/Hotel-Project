using Hotel.Application.Dtos;
using Hotel.Web.Models.EstadoHabitacion;
using Hotel.Web.Models.Habitacion;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Hotel.Web.Services.EstadoHabitacion
{
    public class EstadoHabitacionService : IEstadoHabitacionService
    {
        private readonly HttpClient httpClient;
        private readonly HttpClientHandler httpClientHandler;

        public EstadoHabitacionService()
        {
            this.httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyError) => { return true; };
            httpClient = new HttpClient(httpClientHandler);
        }

        public async Task<EstadoHabitacionListResult> Get()
        {
            var estadosHabitacion = new EstadoHabitacionListResult();

            string url = "http://localhost:5202/api/EstadoHabitacion/GetEstadoHabitaciones";
            using (var response = await httpClient.GetAsync(url))
            {
                estadosHabitacion = await HandleApiResponse<EstadoHabitacionListResult>(response);
            }

            return estadosHabitacion;
        }

        public async Task<EstadoHabitacionResult> GetById(int id)
        {
            var estadoHabitacion = new EstadoHabitacionResult();

            string url = $"http://localhost:5202/api/EstadoHabitacion/GetEstadoHabitacionById?id={id}";
            using (var response = await httpClient.GetAsync(url))
            {
                estadoHabitacion = await HandleApiResponse<EstadoHabitacionResult>(response);
            }

            return estadoHabitacion;
        }

        public async Task<EstadoHabitacionResult> Save(EstadoHabitacionAddDto estadoHabitacionAddDto)
        {
            var estadoHabitacion = new EstadoHabitacionResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionAddDto), Encoding.UTF8, "application/json");

            string url = $"http://localhost:5202/api/EstadoHabitacion/AddEstadoHabitacion";
            using (var response = await httpClient.PostAsync(url, content))
            {
                estadoHabitacion = await HandleApiResponse<EstadoHabitacionResult>(response);
            }

            return estadoHabitacion;
        }

        public async Task<EstadoHabitacionResult> Update(int id, EstadoHabitacionUpdateDto estadoHabitacionUpdateDto)
        {
            var estadoHabitacion = new EstadoHabitacionResult();

            StringContent content = new StringContent(JsonConvert.SerializeObject(estadoHabitacionUpdateDto), Encoding.UTF8, "application/json");
            string url = $"http://localhost:5202/api/EstadoHabitacion/UpdateEstadoHabitacion?id={id}";

            using (var response = await httpClient.PutAsync(url, content))
            {
                estadoHabitacion = await HandleApiResponse<EstadoHabitacionResult>(response);
            }

            return estadoHabitacion;
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
