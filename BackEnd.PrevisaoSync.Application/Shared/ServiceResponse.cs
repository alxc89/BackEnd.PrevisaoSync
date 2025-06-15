namespace BackEnd.PrevisaoSync.Application.Shared;
public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; } = string.Empty;
    public bool Success { get; set; } = true;

    public ServiceResponse() { }

    public ServiceResponse(T data)
    {
        Data = data;
    }
    public ServiceResponse(string message, bool success)
    {
        Message = message;
        Success = success;
    }

    public ServiceResponse(string message, bool success, T data)
    {
        Message = message;
        Data = data;
        Success = success;
    }
}