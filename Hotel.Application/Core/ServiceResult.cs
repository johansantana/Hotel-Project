namespace Hotel.Application.Core;

public class ServiceResult<TData>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public TData? Data { get; set; }
}
