using Domain.Exceptions.Base;

namespace API.Exceptions.Base;

public sealed class ApiException : BaseException
{
    public ApiException(string key) : base(key)
    {
    }
}

