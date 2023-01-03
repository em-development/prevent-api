using Domain.Exceptions.Base;

namespace Domain.Exceptions.General
{
    public sealed class ClassEnumNotFound : DomainException
    {
        private static readonly string _valueKey = "enumerator";
        private static readonly string _messageKey = $"api-exception-class-{{{_valueKey}}}-not-found";

        internal ClassEnumNotFound(string entity, string fieldName) : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, $"api-entity-{entity}-enum-{fieldName}");
        }
    }
}
