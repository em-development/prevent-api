using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public sealed class Title
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Title() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Title(string title)
        {
            Value = title;
        }

        private static bool IsValidNotEmpty(string title)
           => !string.IsNullOrWhiteSpace(title);
        private static bool IsValidTitleLength(string title)
            => title.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string title, string entity)
        {
            if (!IsValidNotEmpty(title))
            {
                throw new EmptyFieldException(entity, "title");
            }
            if (!IsValidTitleLength(title))
            {
                throw new InvalidLengthException(entity, "title", title, FieldMinLength, FieldMaxLength);
            }
        }

        public static Title CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
