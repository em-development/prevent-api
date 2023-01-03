using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Checklist.QuestionsMaintenance.Questions
{
    public sealed class Tips
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Tips() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Tips(string title)
        {
            Value = title;
        }

        private static bool IsValidNotEmpty(string tips)
           => !string.IsNullOrWhiteSpace(tips);
        private static bool IsValidTitleLength(string tips)
            => tips.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string tips, string entity)
        {
            if (!IsValidNotEmpty(tips))
            {
                throw new EmptyFieldException(entity, "tips");
            }
            if (!IsValidTitleLength(tips))
            {
                throw new InvalidLengthException(entity, "tips", tips, FieldMinLength, FieldMaxLength);
            }
        }

        public static Tips CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
