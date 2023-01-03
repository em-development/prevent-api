using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Checklist.QuestionsMaintenance.Questions
{
    public sealed class Key
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Key() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Key(string title)
        {
            Value = title;
        }

        private static bool IsValidNotEmpty(string key)
           => !string.IsNullOrWhiteSpace(key);
        private static bool IsValidTitleLength(string key)
            => key.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string key, string entity)
        {
            if (!IsValidNotEmpty(key))
            {
                throw new EmptyFieldException(entity, "key");
            }
            if (!IsValidTitleLength(key))
            {
                throw new InvalidLengthException(entity, "key", key, FieldMinLength, FieldMaxLength);
            }
        }

        public static Key CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
