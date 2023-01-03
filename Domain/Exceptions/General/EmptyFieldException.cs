using Domain.Exceptions.Base;

namespace Domain.Exceptions.General
{
    public sealed class EmptyFieldException : DomainException
    {
        private static readonly string _valueKey = "fieldName";
        private static readonly string _messageKey = "api-exception-field-is-empty";

        internal EmptyFieldException(string entity, string fieldName) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, $"api-entity-{entity}-field-{fieldName}");
        }
    }
}
