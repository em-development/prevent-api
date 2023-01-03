using AutoMapper;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.Checklist.ChecklistMaintenance;

namespace Application.Mappings.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionQuestionsMapping : Profile
    {
        public ChecklistVersionQuestionsMapping()
        {
            CreateMap<ChecklistVersionQuestions, ChecklistVersionQuestionsDTO>();
        }

    }
}
