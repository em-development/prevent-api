﻿using Domain.Enums.Settings.Checklist.QuestionMaintenance.Questions;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;

namespace DTO.Settings.Checklist.QuestionMaintenance.Questions
{
    public class QuestionVersionDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Version { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Tips { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public QuestionTypeEnum QuestionType { get; set; }
        public bool Required { get; set; }
        public bool EnableNotApply { get; set; }
        public bool RequireSelfInspection { get; set; }
        public bool RequireValidation { get; set; }
        public IEnumerable<AnswerVersionDTO>? Answers { get; set; }
        public IEnumerable<RecommendationVersionDTO>? Recommendations { get; set; }
        public IEnumerable<SubQuestionVersionsDTO>? SubQuestionVersions { get; set; }
    }
}