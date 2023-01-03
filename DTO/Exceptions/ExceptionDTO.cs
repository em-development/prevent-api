using Domain.Exceptions.Base;

namespace DTO.Exceptions
{
    public class ExceptionDTO
    {
        public string Key { get; private set; } = string.Empty;

        public Dictionary<string, object> Values { get; private set; } = new();

        public ExceptionDTO() { }

        public ExceptionDTO(BaseException exception)
        {
            Key = exception.Key;
            Values = exception.Values;
        }

        public ExceptionDTO(string messageKey)
        {
            Key = messageKey;
        }

        public ExceptionDTO AddOrReplaceValues(string valueKey, IFormattable value)
        {
            return AddOrReplaceValues(valueKey, value?.ToString() ?? string.Empty);
        }

        public ExceptionDTO AddOrReplaceValues(string valueKey, string value)
        {
            Values[valueKey] = value;
            return this;
        }
    }
}
