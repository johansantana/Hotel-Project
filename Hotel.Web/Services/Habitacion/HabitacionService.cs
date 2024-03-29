using Hotel.Application.Dtos;
using Hotel.Web.Models.Habitacion;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Hotel.Web.Services.Habitacion
{
    public class HabitacionService : IHabitacionService
    {
        private readonly HttpClient httpClient;
        private readonly HttpClientHandler httpClientHandler;

        public HabitacionService()
        {
            this.httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (sender, cert, chain, sslPolicyError) => { return true; };
            httpClient = new HttpClient(httpClientHandler);
        }

        public async Task<HabitacionListResult> Get()
        {
            var habitaciones = new HabitacionListResult();

            string url = "http://localhost:5202/api/Habitacion/GetHabitaciones";
            using (var response = await httpClient.GetAsync(url))
            {
                habitaciones = await HandleApiResponse<HabitacionListResult>(response);
            }

            return habitaciones;
        }

        public async Task<HabitacionResult> GetById(int id)
        {
            var habitacion = new HabitacionResult();

            string url = $"http://localhost:5202/api/Habitacion/GetHabitacionById?id={id}";
            using (var response = await httpClient.GetAsync(url))
            {
                habitacion = await HandleApiResponse<HabitacionResult>(response);
            }

            return habitacion;
        }

        public async Task<HabitacionResult> Save(HabitacionAddDto habitacionAddDto)
        {
            var habitacion = new HabitacionResult();
            StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionAddDto), Encoding.UTF8, "application/json");

            string url = $"http://localhost:5202/api/Habitacion/AddHabitacion";
            using (var response = await httpClient.PostAsync(url, content))
            {
                habitacion = await HandleApiResponse<HabitacionResult>(response);
            }

            return habitacion;
        }

        public async Task<HabitacionResult> Update(int id, HabitacionUpdateDto habitacionUpdateDto)
        {
            var habitacion = new HabitacionResult();

            StringContent content = new StringContent(JsonConvert.SerializeObject(habitacionUpdateDto), Encoding.UTF8, "application/json");
            string url = $"http://localhost:5202/api/Habitacion/UpdateHabitacion?id={id}";

            using (var response = await httpClient.PutAsync(url, content))
            {
                habitacion = await HandleApiResponse<HabitacionResult>(response);
            }

            return habitacion;
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
