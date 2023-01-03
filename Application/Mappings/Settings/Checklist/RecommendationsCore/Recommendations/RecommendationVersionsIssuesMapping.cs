using AutoMapper;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;

namespace Application.Mappings.Settings.Checklist.RecommendationsCore.Recommendations
{
    public class RecommendationVersionsIssuesMapping : Profile
    {
        public RecommendationVersionsIssuesMapping()
        {
            CreateMap<RecommendationVersionIssue, RecommendationVersionIssuesDTO>();
        }

    }
}
