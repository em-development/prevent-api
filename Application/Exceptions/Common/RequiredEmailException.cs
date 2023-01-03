namespace Application.Exceptions.Common
{
    public sealed class RequiredEmailException : Base.ApplicationException
    {
        private static readonly string _messageKey = "api-exception-an-email-is-required";

        public RequiredEmailException() : base(_messageKey)
        {
        }
    }
}

