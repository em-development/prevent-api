namespace Application.Exceptions.Common
{
    public sealed class FileStorageOperationException : Base.ApplicationException
    {
        private static readonly string _valueKey = "error";
        private static readonly string _messageKey = "api-exception-an-error-was-occurred-when-sent-file-amazon";

        public FileStorageOperationException(string error) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, error);
        }
    }
}