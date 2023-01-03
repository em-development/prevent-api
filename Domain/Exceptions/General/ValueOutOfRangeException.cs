using Domain.Exceptions.Base;

namespace Domain.Exceptions.General
{
    public sealed class ValueOutOfRangeException : DomainException
    {
        private static readonly string _valueKey1 = "fieldName";
        private static readonly string _valueKey2 = "fieldValue";
        private static readonly string _valueKey3 = "minRange";
        private static readonly string _valueKey4 = "maxRange";
        private static readonly string _messageKey = "api-exception-value-out-of-range";

        internal ValueOutOfRangeException(string entity, string fieldName, int fieldValue, int minRange, int maxRange)
            : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey1, $"api-entity-{entity}-field-{fieldName}");
            AddOrReplaceValue(_valueKey2, fieldValue);
            AddOrReplaceValue(_valueKey3, minRange);
            AddOrReplaceValue(_valueKey4, maxRange);
        }

        internal ValueOutOfRangeException(string entity, string fieldName, int fieldValue, int minRange)
            : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey1, $"api-entity-{entity}-field-{fieldName}");
            AddOrReplaceValue(_valueKey2, fieldValue);
            AddOrReplaceValue(_valueKey3, minRange);
        }
    }
}
