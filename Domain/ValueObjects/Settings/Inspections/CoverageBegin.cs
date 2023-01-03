using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Inspections.Inspections
{
    public class CoverageBegin
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 255;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CoverageBegin() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private CoverageBegin(string coverageBegin)
        {
            Value = coverageBegin;
        }

        private static bool IsValidNotEmpty(string coverageBegin)
            => !string.IsNullOrWhiteSpace(coverageBegin);

        private static bool IsValidNameLength(string coverageBegin)
            => coverageBegin.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string coverageBegin, string entity)
        {
            if (!IsValidNotEmpty(coverageBegin))
            {
                throw new EmptyFieldException(entity, "coverageBegin");
            }
            if (!IsValidNameLength(coverageBegin))
            {
                throw new InvalidLengthException(entity, "coverageBegin", coverageBegin, FieldMinLength, FieldMaxLength);
            }
        }

        public static CoverageBegin CreateValid(string coverageBegin, string entity)
        {
            Validate(coverageBegin, entity);
            return new(coverageBegin);
        }
    }
}
