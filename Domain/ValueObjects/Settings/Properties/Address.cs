using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Properties
{
    public class Address
    {
        public static readonly int FieldMinLength = 4;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Address() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Address(string address)
        {
            Value = address;
        }

        private static bool IsValidNotEmpty(string value)
            => !string.IsNullOrWhiteSpace(value);

        private static bool IsValidNameLength(string value)
            => value.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static bool IsValidNames(string value)
            => value.hasMinhWords(2);

        private static void Validate(string address, string entity)
        {
            if (!IsValidNotEmpty(address))
            {
                throw new EmptyFieldException(entity, "address");
            }
            if (!IsValidNameLength(address))
            {
                throw new InvalidLengthException(entity, "address", address, FieldMinLength, FieldMaxLength);
            }
        }

        public static Address CreateValid(string address, string entity)
        {
            Validate(address, entity);
            return new(address);
        }
    }
}
