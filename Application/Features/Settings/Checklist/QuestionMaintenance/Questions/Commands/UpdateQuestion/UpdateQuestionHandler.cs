using Adapters.Repositories.Settings.Checklist.AnswerMaintenance.Answers;
using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Application.Exceptions.Common;
using Application.Features.Settings.Checklist.AnswerMaintenance.Answers.Commands.UpdateAnswer;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.AnswerMaintenance.Answers;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.AnswerMaintenance.Answers;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionRequest, Response<QuestionFormDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionVersionRepository _questionVersionRepository;
        private readonly IQuestionVersionAnswersRepository _questionVersionAnswersRepository;
        private readonly IQuestionVersionRecommendationsRepository _questionVersionRecommendationsRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly ISubQuestionVersionsRepository _subQuestionVersionsRepository;
        private readonly IMapper _mapper;

        public UpdateQuestionHandler(
            IQuestionRepository questionRepository,
            IQuestionVersionRepository questionVersionRepository,
            IQuestionVersionAnswersRepository questionVersionAnswersRepository,
            IQuestionVersionRecommendationsRepository questionVersionRecommendationsRepository,
            ISubQuestionVersionsRepository subQuestionVersionsRepository,
            IAnswerRepository answerRepository,
            IRecommendationRepository recommendationRepository,
            IMapper mapper
            )
        {
            _questionRepository = questionRepository;
            _questionVersionRepository = questionVersionRepository;
            _questionVersionAnswersRepository = questionVersionAnswersRepository;
            _questionVersionRecommendationsRepository = questionVersionRecommendationsRepository;
            _subQuestionVersionsRepository = subQuestionVersionsRepository;
            _answerRepository = answerRepository;
            _recommendationRepository = recommendationRepository;
            _mapper = mapper;
        }

        public async Task<Response<QuestionFormDTO>> Handle(
            UpdateQuestionRequest request,
            CancellationToken cancellationToken)
        {
            Question? question = await _questionRepository.GetByIdAsync(request.Id);

            if (question == null)
            {
                throw new NotFoundException("api-entity-question",
                    ("api-entity-question-field-id", request.Id)
                );
            }

            // Criar AnswerVersion com novo Description
            QuestionVersion questionVersion = new QuestionVersion(
                question.Id, 
                request.Version.Description,
                request.Version.Tips, 
                request.Version.Key,
                request.Version.QuestionType,
                0,
                request.Version.Required,
                request.Version.EnableNotApply,
                request.Version.RequireSelfInspection,
                request.Version.RequireValidation
                );

            questionVersion.IncrementVersion(question.Version?.Version ?? 0);
            questionVersion.SetDescription(request.Version.Description);
            questionVersion = await _questionVersionRepository.InsertAsync(questionVersion);

            question.SetVersion(questionVersion);
            question.SetIsActive(request.IsActive);

            await _questionRepository.UpdateAsync(question);

            if (request.Version != null)
            {
                if (request.Version.Answers != null)
                {
                    foreach (int? answer in request.Version.Answers.Select(x => x.AnswerId))
                    {
                        Answer answerWithVersion = await _answerRepository.GetByIdAsync(answer.Value);
                        await _questionVersionAnswersRepository.InsertAsync(new QuestionVersionAnswers(questionVersion.Id, answerWithVersion.Version.Id));
                    }
                }
            }

            if (request.Version != null)
            {
                if (request.Version.Recommendations != null)
                {
                    foreach (int? recommendation in request.Version.Recommendations.Select(x => x.RecommendationId))
                    {
                        Recommendation recommendationWithVersion = await _recommendationRepository.GetByIdAsync(recommendation.Value);
                        await _questionVersionRecommendationsRepository.InsertAsync(new QuestionVersionRecommendations(questionVersion.Id, recommendationWithVersion.Version.Id));
                    }
                }
            }

            if (request.Version != null)
            {
                if (request.Version.SubQuestionVersions != null)
                {
                    foreach (int? subQuestion in request.Version.SubQuestionVersions.Select(x => x.SubQuestionVersion.Id))
                    {
                        await _subQuestionVersionsRepository.InsertAsync(new SubQuestionVersions(questionVersion.Id, subQuestion.Value));
                    }
                }
            }

            question = await _questionRepository.GetByIdWithVersions(question.Id);

            return new Response<QuestionFormDTO>(_mapper.Map<QuestionFormDTO>(question));
        }
    }
}
