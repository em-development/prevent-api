using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Inspections
{
    public class InspectionPropertyBuildingDescription
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private InspectionPropertyBuildingDescription() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private InspectionPropertyBuildingDescription(string description)
        {
            Value = description;
        }

        private static bool IsValidNotEmpty(string description)
            => !string.IsNullOrWhiteSpace(description);

        private static bool IsValidNameLength(string description)
            => description.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string description, string entity)
        {
            if (!IsValidNotEmpty(description))
            {
                throw new EmptyFieldException(entity, "description");
            }
            if (!IsValidNameLength(description))
            {
                throw new InvalidLengthException(entity, "description", description, FieldMinLength, FieldMaxLength);
            }
        }

        public static InspectionPropertyBuildingDescription CreateValid(string description, string entity)
        {
            Validate(description, entity);
            return new(description);
        }
    }
}
