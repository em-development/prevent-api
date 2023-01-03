using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Inspections.InspectionsPropertyCoverages
{
    public class Coverage
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Coverage() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Coverage(string coverage)
        {
            Value = coverage;
        }

        private static bool IsValidNotEmpty(string coverage)
            => !string.IsNullOrWhiteSpace(coverage);

        private static bool IsValidNameLength(string coverage)
            => coverage.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string coverage, string entity)
        {
            if (!IsValidNotEmpty(coverage))
            {
                throw new EmptyFieldException(entity, "coverage");
            }
            if (!IsValidNameLength(coverage))
            {
                throw new InvalidLengthException(entity, "coverage", coverage, FieldMinLength, FieldMaxLength);
            }
        }

        public static Coverage CreateValid(string coverage, string entity)
        {
            Validate(coverage, entity);
            return new(coverage);
        }
    }
}
