namespace Application.Exceptions.Common
{
    public sealed class UnsupportedFileFormatException : Base.ApplicationException
    {
        private static readonly string _valueKey = "entityName";
        private static readonly string _valueParamsKey = "valueParams";

        private static readonly string _messageKey = "api-exception-file-format-not-supported";

        public UnsupportedFileFormatException(
            string entityName,
            params (string fieldName, IConvertible fieldValue)[] valueParams)
            : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, entityName);
            AddOrReplaceValueInParams(_valueParamsKey, valueParams);
        }
    }
}

