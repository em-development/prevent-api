namespace Application.Exceptions.Common
{
    internal sealed class UserAlreadyExistsException : Base.ApplicationException
    {
        private static readonly string _messageKey = "api-exception-record-already-exists";

        public UserAlreadyExistsException() : base(_messageKey)
        {
        }
    }
}