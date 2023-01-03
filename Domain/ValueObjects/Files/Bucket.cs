using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Files
{
    public class Bucket
    {
        public static readonly int FieldMinLength = 3;
        public static readonly int FieldMaxLength = 100;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Bucket() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private Bucket(string value)
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
                throw new EmptyFieldException(entity, "bucket");
            }
            if (!IsValidNameLength(fileName))
            {
                throw new InvalidLengthException(entity, "bucket", fileName, FieldMinLength, FieldMaxLength);
            }
        }

        public static Bucket CreateValid(string Buket, string entity)
        {
            Validate(Buket, entity);
            return new(Buket);
        }
    }
}
