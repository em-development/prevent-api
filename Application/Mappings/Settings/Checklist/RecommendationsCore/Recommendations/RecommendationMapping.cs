using Application.Services.Files;
using AutoMapper;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Files;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Application.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationMapping : Profile
    {
        public RecommendationMapping()
        {
            CreateMap<Recommendation, RecommendationDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Description.Value : string.Empty))
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Title.Value : string.Empty))
                .ForMember(dto => dto.DueDateText, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.DueDateText.Value : string.Empty))
                .ForMember(dto => dto.Status, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.RecommendationVersionStatusId : 0))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0));

            CreateMap<Recommendation, RecommendationFormDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Description.Value : string.Empty))
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Title.Value : string.Empty))
                .ForMember(dto => dto.DueDateText, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.DueDateText.Value : string.Empty))
                .ForMember(dto => dto.Status, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.RecommendationVersionStatusId : 0))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version));

        }
    }
}
