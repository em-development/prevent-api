using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Inspections.Inspections
{
    public class CoverageEnd
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 255;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CoverageEnd() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private CoverageEnd(string coverageEnd)
        {
            Value = coverageEnd;
        }

        private static bool IsValidNotEmpty(string coverageEnd)
            => !string.IsNullOrWhiteSpace(coverageEnd);

        private static bool IsValidNameLength(string coverageEnd)
            => coverageEnd.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string coverageEnd, string entity)
        {
            if (!IsValidNotEmpty(coverageEnd))
            {
                throw new EmptyFieldException(entity, "coverageEnd");
            }
            if (!IsValidNameLength(coverageEnd))
            {
                throw new InvalidLengthException(entity, "coverageEnd", coverageEnd, FieldMinLength, FieldMaxLength);
            }
        }

        public static CoverageEnd CreateValid(string coverageEnd, string entity)
        {
            Validate(coverageEnd, entity);
            return new(coverageEnd);
        }
    }
}
