using AutoMapper;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace Application.Mappings.Settings.Checklist.AnswerMaintenance.Answears
{
    public class AnswersVersionsMapping : Profile
    {
        public AnswersVersionsMapping()
        {
            CreateMap<AnswerVersion, AnswerVersionDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Description.Value))
                .ForMember(output => output.Issues, x => x.MapFrom(
                        input => input.AnswerVersionIssues != null ?
                            input.AnswerVersionIssues.Select(i => new IssueDTO
                            {
                                Id = i.IssueId,
                                Description = i!.Issue!.Description.Value,
                                IsActive = i.Issue.IsActive,
                                Tags = (i.Issue.Tags != null ? i.Issue.Tags.Select(t => t.Tag.Value).ToArray() : null)!
                            }).ToArray() :
                            null))
                .ReverseMap();
        }
    }
}
