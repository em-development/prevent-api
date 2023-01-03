namespace Application.Exceptions.Common
{
    internal sealed class MoreThanOneRecordsReturnedException : Base.ApplicationException
    {
        private static readonly string _valueKey = "entityName";
        private static readonly string _valueParamsKey = "valueParams";

        private static readonly string _messageKey = "api-exception-more-than-one-records-returned-in";

        internal MoreThanOneRecordsReturnedException(
            string entityName,
            params (string fieldName, IConvertible fieldValue)[] valueParams)
            : base(_messageKey)
        {
            AddOrReplaceValue(_valueKey, entityName);
            AddOrReplaceValueInParams(_valueParamsKey, valueParams);
        }
    }
}
