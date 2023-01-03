using Domain.Exceptions.Users;
using Domain.Extensions;
using System.Net.Mail;

namespace Domain.ValueObjects.General
{
    public class Email
    {
        public static readonly int FieldMinLength = 1;
        public static readonly int FieldMaxLength = 150;

        public string Value { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Email() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #endregion EF Constructor

        private Email(string email)
        {
            Value = email;
        }

        private static bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Length.IsBetween(FieldMinLength, FieldMaxLength))
            {
                return false;
            }

            try
            {
                var mail = new MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static void Validate(string email, string entity)
        {
            if (!IsValid(email))
            {
                throw new InvalidEmailException(entity, email);
            }
        }

        public static Email CreateValid(string email, string entity)
        {
            Validate(email, entity);
            return new(email);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
