namespace Hotel.Api.Core
{
  public class ServiceResult <TData>
  {
    public bool Sucess { get; set; }
    public string? Message { get; set; }
    public TData? Data {get; set; }
  }  
}