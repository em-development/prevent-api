namespace Domain.Exceptions.Base
{
    public abstract class DomainException : BaseException
    {
        protected DomainException(string key) : base(key)
        {
        }
    }
}
