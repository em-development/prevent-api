using AutoMapper;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace Application.Mappings.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionsMapping : Profile
    {
        public QuestionVersionsMapping()
        {
            CreateMap<QuestionVersion, QuestionVersionDTO>()
                 .ForMember(dto => dto.Description, x => x.MapFrom(
                     ent => ent.Description.Value))
                 .ForMember(dto => dto.Key, x => x.MapFrom(
                     ent => ent.Key.Value))
                 .ForMember(dto => dto.Tips, x => x.MapFrom(
                     ent => ent.Tips.Value))
                 .ForMember(dto => dto.QuestionType, x => x.MapFrom(
                     ent => ent.QuestionTypeId))
                 .ForMember(output => output.Answers, x => x.MapFrom(
                         input => input.QuestionVersionAnswers != null ? input.QuestionVersionAnswers.Select(i => new AnswerVersionDTO()
                         {
                             Id = i.AnswerVersion.Id,
                             AnswerId = i.AnswerVersion.AnswerId,
                             Description = i.AnswerVersion.Description.Value,
                             Issues = i.AnswerVersion.AnswerVersionIssues != null ? i.AnswerVersion.AnswerVersionIssues.Select(x => new IssueDTO
                             {
                                 Id = x.Issue.Id,
                                 Description = x.Issue.Description.Value,
                                 Tags = x.Issue.Tags != null ? x.Issue.Tags.Select(x => x.Tag.Value).ToArray() : null
                             }) : null
                         }).ToArray() : null))
                 .ForMember(output => output.Recommendations, x => x.MapFrom(
                         input => input.QuestionVersionRecommendations != null ? input.QuestionVersionRecommendations.Select(i => new RecommendationVersionDTO
                         {
                             Id = i.Id,
                             RecommendationId = i.RecommendationVersion.RecommendationId,
                             Issues = i.RecommendationVersion.RecommendationVersionIssues != null ? i.RecommendationVersion.RecommendationVersionIssues.Select(x => new IssueDTO
                             {
                                 Id = x.Issue.Id,
                                 Description = x.Issue.Description.Value,
                                 Tags = x.Issue.Tags != null ? x.Issue.Tags.Select(x => x.Tag.Value).ToArray() : null
                             }) : null,
                             Title = i.RecommendationVersion.Title.Value,
                             DueDateText = i.RecommendationVersion.DueDateText.Value,
                             Description = i.RecommendationVersion.Description.Value,
                             Status = (RecommendationVersionStatusEnum)i.RecommendationVersion.RecommendationVersionStatusId
                         }).ToArray() : null))
                 
                 .ReverseMap();

        }
    }
}
