using Domain.Exceptions.General;

namespace Domain.ValueObjects.General
{
    public class GuId
    {
        public static readonly int FieldLength = 36;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private GuId() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private GuId(string guid)
        {
            Value = guid;
        }

        private static bool IsValidNotEmpty(string uid) => !string.IsNullOrWhiteSpace(uid);
        private static bool IsValidLength(string uid) => uid.Length == FieldLength;

        private static void Validate(string value, string entity)
        {
            if (!IsValidNotEmpty(value))
            {
                throw new EmptyFieldException(entity, "guid");
            }
            if (!IsValidLength(value))
            {
                throw new InvalidLengthException(entity, "guid", value, FieldLength, FieldLength);
            }

            if (!System.Guid.TryParse(value, out System.Guid newGuid))
            {
                throw new InvalidFieldFormatException(entity, "guid");
            }
        }

        public static GuId CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}
