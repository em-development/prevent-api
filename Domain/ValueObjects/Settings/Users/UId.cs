using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Users
{
    public class UId
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 64;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UId() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private UId(string uId)
        {
            Value = uId;
        }

        private static bool IsValidNotEmpty(string uId) => !string.IsNullOrWhiteSpace(uId);
        private static bool IsValidLength(string uid) => uid.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string uId, string entity)
        {
            if (!IsValidNotEmpty(uId))
            {
                throw new EmptyFieldException(entity, "uid");
            }
            if (!IsValidLength(uId))
            {
                throw new InvalidLengthException(entity, "uid", uId, FieldMinLength, FieldMaxLength);
            }
        }

        public static UId CreateValid(string uId, string entity)
        {
            Validate(entity, uId);
            return new(uId);
        }
    }
}
