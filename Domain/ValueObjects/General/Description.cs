using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.General
{
    public class Description
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 255;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Description() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Description(string description)
        {
            Value = description;
        }

        private static bool IsValidNotEmpty(string description)
            => !string.IsNullOrWhiteSpace(description);
        private static bool IsValidDescriptionLength(string description)
            => description.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string description, string entity)
        {
            if (!IsValidNotEmpty(description))
            {
                throw new EmptyFieldException(entity, "description");
            }
            if (!IsValidDescriptionLength(description))
            {
                throw new InvalidLengthException(entity, "description", description, FieldMinLength, FieldMaxLength);
            }
        }

        public static Description CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
