using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Issues
{
    public sealed class Tag
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Tag() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Tag(string tag)
        {
            Value = tag;
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

        public static Tag CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
