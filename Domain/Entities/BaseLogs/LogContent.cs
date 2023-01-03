using Domain.Entities.Base;

namespace Domain.Entities.BaseLogs
{
    public class LogContent : Entity
    {
        public string Content { get; private set; }
        public virtual Log? Log { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private LogContent()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public LogContent(int id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
