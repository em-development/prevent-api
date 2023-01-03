using AutoMapper;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Application.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionsMapping : Profile
    {
        public RecommendationVersionsMapping()
        {
            CreateMap<RecommendationVersion, RecommendationVersionDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Description.Value))
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Title.Value))
                .ForMember(dto => dto.DueDateText, x => x.MapFrom(
                    ent => ent.DueDateText.Value))
                .ForMember(dto => dto.Status, x => x.MapFrom(
                    ent => ent.RecommendationVersionStatusId))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version))
                .ForMember(output => output.Issues, x => x.MapFrom(
                        input => input.RecommendationVersionIssues != null ?
                            input.RecommendationVersionIssues.Select(i => new IssueDTO
                            {
                                Id = i.IssueId,
                                Description = i.Issue.Description.Value,
                                IsActive = i.Issue.IsActive,
                                Tags = i.Issue.Tags != null ? i.Issue.Tags.Select(x => x.Tag.Value).ToArray() : null
                            }).ToArray() :
                            null))
                .ForMember(dto => dto.Attachments, x => x.MapFrom(
                    input => input.RecommendationAttachments != null ? input.RecommendationAttachments.Select(x => x.Attachment) : null))
                .ReverseMap();
        }
    }
}
