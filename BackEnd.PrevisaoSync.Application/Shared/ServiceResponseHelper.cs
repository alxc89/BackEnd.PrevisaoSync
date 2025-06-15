namespace BackEnd.PrevisaoSync.Application.Shared;
public class ServiceResponseHelper
{
    public static ServiceResponse<T> Success<T>(T data, string message)
    {
        return new ServiceResponse<T>
        {
            Data = data,
            Message = message,
            Success = true
        };
    }

    public static ServiceResponse<T> Success<T>(string message)
    {
        return new ServiceResponse<T>
        {
            Message = message,
            Success = true
        };
    }

    public static ServiceResponse<T> Error<T>(string message)
    {
        return new ServiceResponse<T>
        {
            Message = message,
            Success = false
        };
    }
}