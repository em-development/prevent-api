using Domain.Entities.Base;

namespace Domain.Entities.Settings.Checklist.QuestionMaintenance
{
    public class SubQuestionVersions : Entity
    {
        public int QuestionVersionId { get; private set; }
        public int SubQuestionVersionId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private SubQuestionVersions()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual QuestionVersion? QuestionVersion { get; private set; }
        public virtual QuestionVersion? SubQuestionVersion { get; private set; }

        public SubQuestionVersions(int questionVersionId, int subQuestionVersionId)
        {
            QuestionVersionId = questionVersionId;
            SubQuestionVersionId = subQuestionVersionId;
        }
    }
}
