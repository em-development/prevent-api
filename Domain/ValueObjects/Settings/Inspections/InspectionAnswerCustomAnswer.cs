using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Inspections
{
    public class InspectionAnswerCustomAnswer
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private InspectionAnswerCustomAnswer() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private InspectionAnswerCustomAnswer(string answer)
        {
            Value = answer;
        }

        private static bool IsValidNotEmpty(string answer)
            => !string.IsNullOrWhiteSpace(answer);

        private static bool IsValidNameLength(string answer)
            => answer.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string answer, string entity)
        {
            if (!IsValidNotEmpty(answer))
            {
                throw new EmptyFieldException(entity, "answer");
            }
            if (!IsValidNameLength(answer))
            {
                throw new InvalidLengthException(entity, "answer", answer, FieldMinLength, FieldMaxLength);
            }
        }

        public static InspectionAnswerCustomAnswer CreateValid(string answer, string entity)
        {
            Validate(answer, entity);
            return new(answer);
        }
    }
}
