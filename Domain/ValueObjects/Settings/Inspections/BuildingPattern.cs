using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Inspections
{
    public class BuildingPattern
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private BuildingPattern() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private BuildingPattern(string buildingPattern)
        {
            Value = buildingPattern;
        }

        private static bool IsValidNotEmpty(string buildingPattern)
            => !string.IsNullOrWhiteSpace(buildingPattern);

        private static bool IsValidNameLength(string buildingPattern)
            => buildingPattern.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string buildingPattern, string entity)
        {
            if (!IsValidNotEmpty(buildingPattern))
            {
                throw new EmptyFieldException(entity, "buildingPattern");
            }
            if (!IsValidNameLength(buildingPattern))
            {
                throw new InvalidLengthException(entity, "buildingPattern", buildingPattern, FieldMinLength, FieldMaxLength);
            }
        }

        public static BuildingPattern CreateValid(string buildingPattern, string entity)
        {
            Validate(buildingPattern, entity);
            return new(buildingPattern);
        }
    }
}
