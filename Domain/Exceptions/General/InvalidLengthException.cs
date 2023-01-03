using Domain.Exceptions.Base;

namespace Domain.Exceptions.General
{
    public sealed class InvalidLengthException : DomainException
    {
        private static readonly string _valueKey1 = "fieldName";
        private static readonly string _valueKey2 = "fieldValue";
        private static readonly string _valueKey3 = "fieldLength";
        private static readonly string _valueKey4 = "fieldLengthMinLimit";
        private static readonly string _valueKey5 = "fieldLengthMaxLimit";

        private static readonly string _messageKey = "api-exception-length-is-invalid";

        internal InvalidLengthException(
            string entity,
            string fieldName,
            string fieldValue,
            int fieldLengthMinLimit,
            int fieldLengthMaxLimit)
            : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey1, $"api-entity-{entity}-field-{fieldName}");
            AddOrReplaceValue(_valueKey2, fieldValue);
            AddOrReplaceValue(_valueKey3, fieldValue.Length);
            AddOrReplaceValue(_valueKey4, fieldLengthMinLimit);
            AddOrReplaceValue(_valueKey5, fieldLengthMaxLimit);
        }
    }
}
