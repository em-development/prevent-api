using AutoMapper;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;

namespace Application.Mappings.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionMapping : Profile
    {
        public QuestionMapping()
        {
            CreateMap<Question, QuestionDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Description.Value : string.Empty))
                .ForMember(dto => dto.QuestionType, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.QuestionTypeId : 0))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0));

            CreateMap<Question, QuestionFormDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Description.Value : string.Empty))
                .ForMember(dto => dto.QuestionType, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.QuestionTypeId : 0))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version));

        }
    }
}
