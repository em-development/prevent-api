using Domain.Entities.Base;
using Domain.Entities.Files;

namespace Domain.Compacts.Settings.Users
{
    public class CompactUser : Entity
    {
        public string Name { get; private set; }
        public string UId { get; private set; }
        public string? Email { get; private set; }

        public int? AttachmentId { get; private set; }

        public virtual Attachment? Avatar { get; set; }

        #region EF Constructor
#pragma warning disable CS8618
        private CompactUser()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor
    }
}
