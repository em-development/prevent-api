using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace Application.Mappings.Settings.Checklist.RecommendationsCore.Issues
{
    public class IssuesMapping : Profile
    {
        public IssuesMapping()
        {
            CreateMap<Issue, IssueDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Description == null ? null : ent.Description.Value))
                .ForMember(dto => dto.Tags, x => x.MapFrom(
                    ent => ent.Tags == null ? new string[0] : ent.Tags.Select(t => t.Tag.Value).ToArray()));
        }

    }
}
