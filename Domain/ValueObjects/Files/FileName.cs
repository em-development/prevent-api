using Domain.Exceptions.Files;
using Domain.Exceptions.General;
using Domain.Extensions;

namespace Domain.ValueObjects.Files
{
    public class FileName
    {
        public static readonly int FieldMinLength = 2;
        public static readonly int FieldMaxLength = 250;
        public static readonly string[] AllowedExtensions = new string[] { "jpg", "jpeg", "png", "pdf", "xlsx" };

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private FileName() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        private FileName(string value)
        {
            Value = value;
        }

        private static bool IsValidNotEmpty(string fileName)
            => !string.IsNullOrWhiteSpace(fileName);

        private static bool IsValidNameLength(string fileName)
            => fileName.Length.IsBetween(FieldMinLength, FieldMaxLength);

        private static bool isValidFileName(string extesion)
            => extesion != null;

        private static bool isAllowedFileExtension(string extension, string[]? allowed)
            => AllowedExtensions.Contains(extension.ToLower())
                && (allowed == null || allowed.Length == 0 || allowed.Contains(extension.ToLower()));


        private static void Validate(string fileName, string entity, string[]? allowedExtensions)
        {
            string extension = Path.GetExtension(fileName);

            if (!IsValidNotEmpty(fileName))
            {
                throw new EmptyFieldException(entity, "fileName");
            }
            if (!IsValidNameLength(fileName))
            {
                throw new InvalidLengthException(entity, "fileName", fileName, FieldMinLength, FieldMaxLength);
            }
            if (!isValidFileName(extension))
            {
                throw new InvalidFileNameException(fileName);
            }
            //if (!isAllowedFileExtension(fileName, allowedExtensions))
            //{
            //    throw new InvalidFileExtensionException(fileName);
            //}
        }

        public static FileName CreateValid(string fileName, string entity, string[]? allowedExtensions = null)
        {
            Validate(fileName, entity, allowedExtensions);
            return new(fileName);
        }
    }
}
