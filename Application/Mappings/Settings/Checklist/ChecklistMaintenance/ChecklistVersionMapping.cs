using AutoMapper;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;
using DTO.Settings.Checklist.ChecklistMaintenance;
using Domain.Entities.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.RecommendationsCore.Issues;

namespace Application.Mappings.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistVersionsMapping : Profile
    {
        public ChecklistVersionsMapping()
        {
            CreateMap<ChecklistVersion, ChecklistVersionDTO>()
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Title.Value))
                .ForMember(dto => dto.Key, x => x.MapFrom(
                    ent => ent.Key.Value))
                .ForMember(output => output.Questions, x => x.MapFrom(
                    input => input.ChecklistVersionQuestions != null
                        ? input.ChecklistVersionQuestions.Select(i => new QuestionVersionDTO
                        {
                            Id = i.Question!.VersionId!.Value,
                            Description = i.Question.Version!.Description.Value,
                            QuestionType = (QuestionTypeEnum) i.Question.Version.QuestionTypeId,
                            QuestionId = i.Question.Id,
                            Key = i.Question.Version.Key.Value,
                            Tips = i.Question.Version.Tips.Value,
                            Answers = i.Question.Version.QuestionVersionAnswers != null
                                ? i.Question.Version.QuestionVersionAnswers.Select(a => new AnswerVersionDTO
                                {
                                    Id = a.AnswerVersion!.Id,
                                    Description = a.AnswerVersion.Description.Value,
                                    Issues = a.AnswerVersion.AnswerVersionIssues != null
                                        ? a.AnswerVersion.AnswerVersionIssues.Select(avi => new IssueDTO
                                        {
                                            Id = avi.IssueId,
                                            Description = avi.Issue!.Description.Value
                                        })
                                        : null
                                }).ToArray()
                                : null
                        }).ToArray()
                        : null))
                .ReverseMap();
        }
    }
}