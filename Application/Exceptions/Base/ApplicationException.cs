using Domain.Exceptions.Base;

namespace Application.Exceptions.Base
{
    public abstract class ApplicationException : BaseException
    {
        protected ApplicationException(string key) : base(key)
        {
        }
    }
}
