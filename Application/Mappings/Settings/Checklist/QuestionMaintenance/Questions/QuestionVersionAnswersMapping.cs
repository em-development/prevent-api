using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;

namespace Application.Mappings.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionAnswersMapping : Profile
    {
        public QuestionVersionAnswersMapping()
        {
            CreateMap<QuestionVersionAnswers, QuestionVersionAnswersDTO>();
        }

    }
}
