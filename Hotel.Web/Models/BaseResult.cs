namespace Hotel.Web.Models
{
    public abstract class BaseResult
    {
        public bool success { get; set; }
        public string? message { get; set; }
    }
}
