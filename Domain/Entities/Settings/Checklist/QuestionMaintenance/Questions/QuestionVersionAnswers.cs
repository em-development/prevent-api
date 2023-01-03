using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Domain.Entities.Settings.Checklist.QuestionMaintenance
{
    public class QuestionVersionAnswers : Entity
    {
        public int QuestionVersionId { get; private set; }
        public int AnswerVersionId { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private QuestionVersionAnswers()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual QuestionVersion? QuestionVersion { get; private set; }
        public virtual AnswerVersion? AnswerVersion { get; private set; }

        public QuestionVersionAnswers(int questionVersionId, int answerVersionId)
        {
            QuestionVersionId = questionVersionId;
            AnswerVersionId = answerVersionId;
        }
    }
}
