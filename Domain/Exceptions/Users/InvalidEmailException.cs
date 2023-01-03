using Domain.Exceptions.Base;

namespace Domain.Exceptions.Users
{
    public sealed class InvalidEmailException : DomainException
    {
        private static readonly string _valueKey = "email";
        private static readonly string _messageKey = "api-exception-invalid-email-address";
        internal InvalidEmailException(string entity, string fieldName) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, $"api-entity-{entity}-field-{fieldName}");
        }
    }
}
