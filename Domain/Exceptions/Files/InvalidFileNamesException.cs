using Domain.Exceptions.Base;

namespace Domain.Exceptions.Files
{
    public sealed class InvalidFileNameException : DomainException
    {
        private static readonly string _valueKey = "fileName";
        private static readonly string _messageKey = "api-exception-invalid-file-name";
        internal InvalidFileNameException(string name) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, name);
        }
    }
}
