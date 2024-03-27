using Hotel.Web.Core;
namespace Hotel.Web.EndpoitComponent.Categoria
{
    public class CategoriasEnpoints 
    {
        //public static string EnpointGetAll { get; } = "https://localhost:7234/api/Categoria/GetCategoria";
        //public static string EnpointGet { get; } = "https://localhost:7234/api/Categoria/GetCategoriaById?id=";
        //public static string EnpointPost { get; } = "https://localhost:7234/api/Categoria/SaveCategoria";
        //public static string EnpointPut { get; } = "https://localhost:7234/api/Categoria/UpdateCategoria";
        //public static string EnpointDelete { get; } = "https://localhost:7234/api/Categoria/DeleteCategoria?id=";

        public static string EnpointGetAll()
        {
            return "https://localhost:7234/api/Categoria/GetCategoria";
        }
        public static string EnpointGet(int id)
        {
            return $"https://localhost:7234/api/Categoria/GetCategoriaById?id={id}"; 
        }
        public static  string EnpointPost()
        {
            return "https://localhost:7234/api/Categoria/SaveCategoria";
        }
        public static string EnpointUpdate()
        {
            return "https://localhost:7234/api/Categoria/UpdateCategoria";
        }
        public static string EnpointDelete(int id)
        {
            return $"https://localhost:7234/api/Categoria/DeleteCategoria?id={id}";
        }
    }
}
