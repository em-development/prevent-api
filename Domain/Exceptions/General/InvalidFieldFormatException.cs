using Domain.Exceptions.Base;

namespace Domain.Exceptions.General
{
    public sealed class InvalidFieldFormatException : DomainException
    {
        private static readonly string _valueKey = "fieldName";
        private static readonly string _messageKey = "api-exception-field-is-invalid";

        internal InvalidFieldFormatException(string entity, string fieldName) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, $"api-entity-{entity}-field-{fieldName}");
        }
    }
}
