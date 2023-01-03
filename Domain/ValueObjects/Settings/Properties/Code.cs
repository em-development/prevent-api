using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Settings.Properties
{
    public class Code
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 50;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Code() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Code(string codeEntity)
        {
            Value = codeEntity;
        }

        private static bool IsValidNotEmpty(string codeEntity)
            => !string.IsNullOrWhiteSpace(codeEntity);
        private static bool IsValidDescriptionLength(string codeEntity)
            => codeEntity.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string code, string entity)
        {
            //if (!IsValidNotEmpty(code))
            //{
            //    throw new EmptyFieldException(entity, "code");
            //}
            //if (!IsValidDescriptionLength(code))
            //{
            //    throw new InvalidLengthException(entity, "code", code, FieldMinLength, FieldMaxLength);
            //}
        }

        public static Code CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}