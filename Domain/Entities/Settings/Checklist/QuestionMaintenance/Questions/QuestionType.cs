using Domain.Entities.Base;
using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.ValueObjects.General;

namespace Domain.Entities.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionType : Entity
    {
        public EnumDescription Description { get; private set; }

        #region EF Constructor
#pragma warning disable CS8618
        private QuestionType()
        {

        }
#pragma warning restore CS8618
        #endregion EF Constructor

        public virtual IEnumerable<QuestionVersion>? QuestionVersions { get; private set; }

        public QuestionType(QuestionTypeEnum groupEnum)
        {
            Id = (int)groupEnum;
            Description = EnumDescription.CreateValid(typeof(QuestionTypeEnum), groupEnum, GetType().Name.ToLower());
        }

    }
}