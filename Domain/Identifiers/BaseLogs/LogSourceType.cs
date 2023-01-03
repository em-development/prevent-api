namespace Domain.Identifiers.BaseLogs
{
    public class LogSouceType
    {
        public string Value { get; private set; }

        private LogSouceType(string type)
        {
            Value = type;
        }

        public static LogSouceType SETTINGS_PEOPLE { get { return new("SETTINGS_PEOPLE"); } }
        public static LogSouceType SETTINGS_ISSUE { get { return new("SETTINGS_ISSUE"); } }
        public static LogSouceType SETTINGS_ISSUE_TAGS { get { return new("SETTINGS_ISSUE_TAGS"); } }
        public static LogSouceType SETTINGS_RECOMMENDATION { get { return new("SETTINGS_RECOMMENDATION"); } }
        public static LogSouceType SETTINGS_RECOMMENDATION_ISSUES { get { return new("SETTINGS_RECOMMENDATION_ISSUES"); } }
        public static LogSouceType SETTINGS_INSPECTIONS { get { return new("SETTINGS_INSPECTIONS"); } }
    }
}
