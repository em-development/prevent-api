using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.General
{
    public class EnumDescription
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected EnumDescription() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        protected EnumDescription(string description)
        {
            Value = description;
        }

        private static bool IsValidNotEmpty(string value)
            => !string.IsNullOrWhiteSpace(value);
        private static bool IsValidDescriptionLength(string value)
            => value.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static string Validate(Type? type, object value, string entity)
        {
            if (type == null)
            {
                throw new ClassEnumNotFound(entity, "enumerator");
            }

            string? keyDesciption = Enum.GetName(type, value);

            if (keyDesciption == null)
            {
                throw new EmptyFieldException(entity, "enumerator-value");
            }

            if (!IsValidDescriptionLength(keyDesciption))
            {
                throw new InvalidLengthException(entity, "description", keyDesciption, FieldMinLength, FieldMaxLength);
            }

            return keyDesciption;
        }

        public static EnumDescription CreateValid(Type? type, object value, string entity)
        {
            return new(Validate(type, value, entity));
        }
    }
}
