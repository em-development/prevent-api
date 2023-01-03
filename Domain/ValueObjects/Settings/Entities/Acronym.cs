using Domain.Exceptions.General;
using Domain.Exceptions.Users;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Entities
{
    public class Acronym
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 20;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Acronym() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Acronym(string acronym)
        {
            Value = acronym;
        }

        private static bool IsValidNotEmpty(string acronym)
            => !string.IsNullOrWhiteSpace(acronym);

        private static bool IsValidNameLength(string acronym)
            => acronym.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string acronym, string entity)
        {
            if (!IsValidNotEmpty(acronym))
            {
                throw new EmptyFieldException(entity, "acronym");
            }
            if (!IsValidNameLength(acronym))
            {
                throw new InvalidLengthException(entity, "acronym", acronym, FieldMinLength, FieldMaxLength);
            }
            if (acronym.Split(" ").Length > 1)
            {
                throw new InvalidNumberOfNamesException("acronym");
            }
        }

        public static Acronym CreateValid(string acronym, string entity)
        {
            Validate(acronym, entity);
            return new(acronym);
        }
    }
}
