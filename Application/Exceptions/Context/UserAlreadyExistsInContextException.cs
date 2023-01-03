namespace Application.Exceptions.Context
{
    internal sealed class UserAlreadyExistsInContextException : Base.ApplicationException
    {
        private static readonly string _messageKey = "api-exception-user-already-have-in-context";
        public UserAlreadyExistsInContextException() : base(_messageKey)
        {
        }
    }
}
