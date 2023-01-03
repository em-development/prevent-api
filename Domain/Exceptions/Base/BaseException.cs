namespace Domain.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        public string Key { get; private set; }
        public Dictionary<string, object> Values { get; private set; } = new();

        protected BaseException(string key) : base(key)
        {
            Key = key;
        }

        protected void AddOrReplaceValue(string key, IConvertible value)
        {
            Values[key] = value?.ToString() ?? string.Empty;
        }

        protected void AddOrReplaceValueInParams(string paramsKey, (string key, IConvertible value)[] paramsValues)
        {
            foreach (var p in paramsValues)
            {
                AddOrReplaceValueInParams(paramsKey, p.key, p.value);
            }
        }

        protected void AddOrReplaceValueInParams(string paramsKey, string key, IConvertible value)
        {
            object obj = Values.GetValueOrDefault(paramsKey) ?? new Dictionary<string, string>();
            if (obj is Dictionary<string, string> @subValues)
            {
                subValues[key] = value?.ToString() ?? string.Empty;
                Values[paramsKey] = subValues;
            }
        }
    }
}
