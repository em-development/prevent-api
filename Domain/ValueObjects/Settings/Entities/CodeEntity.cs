using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.General
{
    public class CodeEntity
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 50;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private CodeEntity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private CodeEntity(string codeEntity)
        {
            Value = codeEntity;
        }

        private static bool IsValidNotEmpty(string codeEntity)
            => !string.IsNullOrWhiteSpace(codeEntity);
        private static bool IsValidDescriptionLength(string codeEntity)
            => codeEntity.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string codeEntity, string entity)
        {
            if (!IsValidNotEmpty(codeEntity))
            {
                throw new EmptyFieldException(entity, "codeEntity");
            }
            if (!IsValidDescriptionLength(codeEntity))
            {
                throw new InvalidLengthException(entity, "codeEntity", codeEntity, FieldMinLength, FieldMaxLength);
            }
        }

        public static CodeEntity CreateValid(string value, string entity)
        {
            Validate(value, entity);
            return new(value);
        }
    }
}