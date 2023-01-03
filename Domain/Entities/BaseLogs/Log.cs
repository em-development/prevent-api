using Domain.Entities.Base;
using Domain.Entities.Settings.Users;

namespace Domain.Entities.BaseLogs
{
    public class Log : Entity
    {
        public string Source { get; private set; }
        public string Owner { get; private set; }
        public string? Reference { get; private set; }
        public string Action { get; private set; }
        public int UserId { get; private set; }
        public DateTime Date { get; private set; }

        public virtual User? User { get; private set; }
        public virtual LogContent? LogContent { get; set; }

        #region EF Constructor
#pragma warning disable CS8618
        private Log()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public Log(string source, string owner, string? reference, string action, int userId)
        {
            Source = source; ;
            Owner = owner;
            Reference = reference;
            Action = action;
            UserId = userId;
            Date = DateTime.Now;
        }
    }
}
