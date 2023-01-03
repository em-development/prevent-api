using Domain.Exceptions.General;
using Domain.Exceptions.Users;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Entities
{
    public class Name
    {
        public static readonly int FieldMinLength = 4;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Name() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Name(string name)
        {
            Value = name;
        }

        private static bool IsValidNotEmpty(string value)
            => !string.IsNullOrWhiteSpace(value);

        private static bool IsValidNameLength(string value)
            => value.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static bool IsValidNames(string value)
            => value.hasMinhWords(2);

        private static void Validate(string name, string entity)
        {
            if (!IsValidNotEmpty(name))
            {
                throw new EmptyFieldException(entity, "name");
            }
            if (!IsValidNameLength(name))
            {
                throw new InvalidLengthException(entity, "name", name, FieldMinLength, FieldMaxLength);
            }
            //if (!IsValidNames(name))
            //{
            //    throw new InvalidNumberOfNamesException("name");
            //}
        }

        public static Name CreateValid(string name, string entity)
        {
            Validate(name, entity);
            return new(name);
        }
    }
}
