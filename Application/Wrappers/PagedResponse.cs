namespace Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int Length { get; set; }

        public PagedResponse(T data, int length)
        {
            Length = length;
            Data = data;
            Message = null;
            Succeeded = true;
        }
    }
}
