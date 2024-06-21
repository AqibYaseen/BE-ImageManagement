using System.Net;

namespace BE_ImageManagement.Models;

public class ApiResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }


    public static ApiResponse<T> Success(T Data, string message, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ApiResponse<T>
        {
            Data = Data,
            IsSuccess = true,
            Message = message,
            StatusCode = status
        };
    }

    public static ApiResponse<T> Error(string message, HttpStatusCode status = HttpStatusCode.OK)
    {
        return new ApiResponse<T>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = status
        };
    }
}
