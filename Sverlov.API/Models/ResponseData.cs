namespace Sverlov.API.Models
{
    public class ResponseData<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string? ErrorMessage { get; set; }

        public static ResponseData<T> OK(T data) => new() { Data = data, Success = true };

        public static ResponseData<T> Error(string message) => new()
        {
            Success = false,
            ErrorMessage = message
        };
    }
}
