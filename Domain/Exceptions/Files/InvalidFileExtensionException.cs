using Domain.Exceptions.Base;

namespace Domain.Exceptions.Files
{
    public sealed class InvalidFileExtensionException : DomainException
    {
        private static readonly string _valueKey = "fileName";
        private static readonly string _messageKey = "api-exception-invalid-file-extension";
        internal InvalidFileExtensionException(string fileName) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, fileName);
        }
    }
}
