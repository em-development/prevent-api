using AutoMapper;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;

namespace Application.Mappings.Settings.Checklist.AnswerMaintenance.Answers
{
    public class AnswersVersionsIssuesMapping : Profile
    {
        public AnswersVersionsIssuesMapping()
        {
            CreateMap<AnswerVersionIssues, AnswerVersionIssuesDTO>();
        }

    }
}
