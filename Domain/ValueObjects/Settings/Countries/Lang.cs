using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Countries
{
    public class Lang
    {
        public static readonly int FieldMinLength = 5;
        public static readonly int FieldMaxLength = 5;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Lang() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Lang(string value)
        {
            Value = value;
        }

        private static bool IsValidNotEmpty(string value)
            => !string.IsNullOrWhiteSpace(value);

        private static bool IsValidDescriptionLength(string value)
            => value.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string value, string entity)
        {
            if (!IsValidNotEmpty(value))
            {
                throw new EmptyFieldException(entity, "value");
            }
            if (!IsValidDescriptionLength(value))
            {
                throw new InvalidLengthException(entity, "value", value, FieldMinLength, FieldMaxLength);
            }
        }

        public static Lang CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
