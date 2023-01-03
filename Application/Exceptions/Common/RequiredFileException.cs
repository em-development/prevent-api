namespace Application.Exceptions.Common
{
    public sealed class RequiredFileException : Base.ApplicationException
    {
        private static readonly string _messageKey = "api-exception-a-file-is-required";

        public RequiredFileException() : base(_messageKey)
        {
        }
    }
}

