namespace Domain.Identifiers.BaseLogs
{
    public class LogActionType
    {
        public string Value { get; private set; }

        private LogActionType(string type)
        {
            Value = type;
        }

        public static LogActionType CREATED { get { return new("CREATED"); } }
        public static LogActionType UPDATED { get { return new("UPDATED"); } }
        public static LogActionType DELETED { get { return new("DELETED"); } }
        public static LogActionType APPROVED { get { return new("APPROVED"); } }
        public static LogActionType DISAPPROVED { get { return new("DISAPPROVED"); } }
        public static LogActionType SYNCED { get { return new("SYNCED"); } }
        public static LogActionType LINKED { get { return new("LINKED"); } }
        public static LogActionType UNLINKED { get { return new("UNLINKED"); } }
        public static LogActionType DRAFT { get { return new("DRAFT"); } }
        public static LogActionType SCHEDULED { get { return new("SCHEDULED"); } }
        public static LogActionType UPDATE_SCHEDULED { get { return new("UPDATE_SCHEDULED"); } }
        public static LogActionType IN_PROGRESS { get { return new("IN_PROGRESS"); } }
        public static LogActionType WAITING_ANALISYS { get { return new("WAITING_ANALISYS"); } }
        public static LogActionType CONCLUDED { get { return new("CONCLUDED"); } }
        public static LogActionType CANCELED { get { return new("CANCELED"); } }
    }
}
