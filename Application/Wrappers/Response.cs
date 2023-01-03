using DTO.Exceptions;

namespace Application.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(ExceptionDTO exception)
        {
            Succeeded = false;
            this.exception = exception;
        }

        public Response(string? message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public ExceptionDTO? exception { get; set; }
        public T? Data { get; set; }
    }
}
