namespace Application.Exceptions.Common
{
    public sealed class PleaseSyncParentLegalEntity : Base.ApplicationException
    {
        private static readonly string _valueKey = "entityName";
        private static readonly string _valueParamsKey = "valueParams";

        private static readonly string _messageKey1 = "api-exception-please-sync-parent-legal-entity";

        internal PleaseSyncParentLegalEntity(
            string entityName,
            params (string fieldName, IConvertible fieldValue)[] paramValues) : base(_messageKey1)
        {
            AddOrReplaceValue(_valueKey, entityName);
            AddOrReplaceValueInParams(_valueParamsKey, paramValues);
        }
    }
}
