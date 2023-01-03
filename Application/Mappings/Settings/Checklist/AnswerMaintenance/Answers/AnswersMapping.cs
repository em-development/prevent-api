using AutoMapper;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace Application.Mappings.Settings.Checklist.AnswerMaintenance.Answears
{
    public class AnswersMapping : Profile
    {
        public AnswersMapping()
        {
            CreateMap<Answer, AnswerDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Description.Value : string.Empty))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0));

            CreateMap<AnswerVersionIssues, AnswerVersionIssuesDTO>();

            CreateMap<Answer, AnswerFormDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Description.Value : string.Empty))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0))
                .ForMember(dto => dto.AnswerVersion, x => x.MapFrom(
                    ent => ent.Version));

        }
    }
}
