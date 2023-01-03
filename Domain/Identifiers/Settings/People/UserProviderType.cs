namespace CC.Domain.Identifiers.BaseLogs
{
    public class UserProviderType
    {
        #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UserProviderType() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion EF Constructor

        public string Value { get; private set; }

        private UserProviderType(string type)
        {
            Value = type;
        }

        public static UserProviderType PASSWORD { get { return new("password"); } }
        public static UserProviderType GOOGLE { get { return new("google.com"); } }
        public static UserProviderType FACEBOOK { get { return new("facebook.com"); } }
        public static UserProviderType MICROSOFT { get { return new("microsoft.com"); } }
    }
}
