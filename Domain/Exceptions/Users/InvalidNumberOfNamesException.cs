using Domain.Exceptions.Base;

namespace Domain.Exceptions.Users
{
    public sealed class InvalidNumberOfNamesException : DomainException
    {
        private static readonly string _valueKey = "name";
        private static readonly string _messageKey = "api-exception-invalid-people-number-of-names";
        internal InvalidNumberOfNamesException(string name) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, name);
        }
    }
}
