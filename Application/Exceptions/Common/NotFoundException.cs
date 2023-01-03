namespace Application.Exceptions.Common
{
    public sealed class NotFoundException : Base.ApplicationException
    {
        private static readonly string _valueKey = "entityName";
        private static readonly string _valueParamsKey = "valueParams";

        private static readonly string _messageKey1 = "api-exception-record-was-not-found-by";

        internal NotFoundException(
            string entityName,
            params (string fieldName, IConvertible fieldValue)[] paramValues) : base(_messageKey1)
        {
            AddOrReplaceValue(_valueKey, entityName);
            AddOrReplaceValueInParams(_valueParamsKey, paramValues);
        }
    }
}
