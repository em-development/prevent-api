using Domain.Entities.Base;
using Domain.Entities.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionAnswers;
using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Checklist.QuestionsMaintenance.Questions;

namespace Domain.Entities.Settings.Checklist.QuestionMaintenance
{
    public class QuestionVersion : Entity
    {
        public int QuestionId { get; private set; }
        public Description Description { get; private set; }
        public Tips Tips { get; private set; }
        public Key Key { get; private set; }
        public int QuestionTypeId { get; private set; }
        public int Version { get; private set; }
        public bool Required { get; private set; }
        public bool EnableNotApply { get; private set; }
        public bool RequireSelfInspection { get; private set; }
        public bool RequireValidation { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private QuestionVersion()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual Question? Question { get; private set; }
        public virtual IEnumerable<QuestionVersionRecommendations>? QuestionVersionRecommendations { get; private set; }
        public virtual IEnumerable<QuestionVersionAnswers>? QuestionVersionAnswers { get; private set; }
        public virtual IEnumerable<SubQuestionVersions>? SubQuestionVersions { get; private set; }
        public virtual IEnumerable<SubQuestionVersions>? SubQuestionVersionsSubQuestionVersions { get; private set; }
        public virtual QuestionType? QuestionType { get; private set; }
        public virtual IEnumerable<InspectionAnswer>? InspectionAnswers { get; private set; }

        public QuestionVersion(
            int questionId, 
            string description, 
            string tips, 
            string key,
            QuestionTypeEnum questionTypeEnum,
            int version,
            bool required,
            bool enableNotApply,
            bool requireSelfInspection,
            bool requireValidation
        )
        {
            QuestionId = questionId;
            Description = Description.CreateValid(description, GetType().Name);
            Tips = Tips.CreateValid(tips, GetType().Name);
            Key = Key.CreateValid(key, GetType().Name);
            QuestionTypeId = (int)questionTypeEnum;
            Version = version;
            Required = required;
            EnableNotApply = enableNotApply;
            RequireSelfInspection = requireSelfInspection;
            RequireValidation = requireValidation;
        }

        public void IncrementVersion(int currentVersion)
        {
            Version = currentVersion + 1;
        }

        public void SetDescription(string description)
        {
            Description = Description.CreateValid(description, GetType().Name);
        }
    }
}
