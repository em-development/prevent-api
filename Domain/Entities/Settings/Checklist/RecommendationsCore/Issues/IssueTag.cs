using Domain.Entities.Base;
using Domain.ValueObjects.Settings.Checklist.RecommendationsCore.Issues;

namespace Domain.Entities.Settings.Checklist.RecommendationsCore.Issues
{
    public class IssueTag : Entity
    {
        public int IssueId { get; private set; }
        public Tag Tag { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private IssueTag()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Issue? Issue { get; private set; }

        public IssueTag(int issueId, string tag)
        {
            IssueId = issueId;
            Tag = Tag.CreateValid(tag, this.GetType().Name);
        }

        public object GetToLog()
        {
            return new
            {
                IssueId = IssueId,
                Tag = Tag.Value
            };
        }
    }
}
