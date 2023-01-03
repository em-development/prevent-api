using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Files
{
    public class ContentType
    {
        public static readonly int FieldMinLength = 3;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private ContentType() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private ContentType(string value)
        {
            Value = value;
        }

        private static bool IsValidNotEmpty(string fileName)
            => !string.IsNullOrWhiteSpace(fileName);

        private static bool IsValidNameLength(string fileName)
            => fileName.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static void Validate(string fileName, string entity)
        {
            string extension = Path.GetExtension(fileName);

            if (!IsValidNotEmpty(fileName))
            {
                throw new EmptyFieldException(entity, "contentType");
            }
            if (!IsValidNameLength(fileName))
            {
                throw new InvalidLengthException(entity, "contentType", fileName, FieldMinLength, FieldMaxLength);
            }
        }

        public static ContentType CreateValid(string contentType, string entity)
        {
            Validate(contentType, entity);
            return new(contentType);
        }
    }
}
