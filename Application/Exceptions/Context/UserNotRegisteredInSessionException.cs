namespace Application.Exceptions.Context
{
    public sealed class UserNotRegisteredInSessionException : Base.ApplicationException
    {
        private static readonly string _messageKey = "api-exception-user-not-registered-in-session";
        public UserNotRegisteredInSessionException() : base(_messageKey)
        {
        }
    }
}
