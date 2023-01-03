using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Recommendations
{
    public sealed class DueDateText
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DueDateText() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private DueDateText(string dueDateText)
        {
            Value = dueDateText;
        }

        private static bool IsValidNotEmpty(string dueDateText)
           => !string.IsNullOrWhiteSpace(dueDateText);
        private static bool IsValidTitleLength(string dueDateText)
            => dueDateText.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string dueDateText, string entity)
        {
            if (!IsValidNotEmpty(dueDateText))
            {
                throw new EmptyFieldException(entity, "dueDateText");
            }
            if (!IsValidTitleLength(dueDateText))
            {
                throw new InvalidLengthException(entity, "dueDateText", dueDateText, FieldMinLength, FieldMaxLength);
            }
        }

        public static DueDateText CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
