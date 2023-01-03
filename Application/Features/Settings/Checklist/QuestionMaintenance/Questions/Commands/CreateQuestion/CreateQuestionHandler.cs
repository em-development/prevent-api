using Adapters.Repositories.Settings.Checklist.QuestionMaintenance.Questions;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Checklist.QuestionMaintenance;
using DTO.Settings.Checklist.QuestionMaintenance.Questions;
using MediatR;

namespace Application.Features.Settings.Checklist.QuestionMaintenance.Questions.Commands.CreateQuestion
{
    internal class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, Response<QuestionFormDTO>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionVersionRepository _questionVersionRepository;
        private readonly IQuestionVersionAnswersRepository _questionVersionAnswersRepository;
        private readonly IQuestionVersionRecommendationsRepository _questionVersionRecommendationsRepository;
        private readonly ISubQuestionVersionsRepository _subQuestionVersionsRepository;
        private readonly IMapper _mapper;

        public CreateQuestionHandler(
            IQuestionRepository questionRepository,
            IQuestionVersionRepository questionVersionRepository,
            IQuestionVersionAnswersRepository questionVersionAnswersRepository,
            IQuestionVersionRecommendationsRepository questionVersionRecommendationsRepository,
            ISubQuestionVersionsRepository subQuestionVersionsRepository,
            IMapper mapper
            )
        {
            _questionRepository = questionRepository;
            _questionVersionRepository = questionVersionRepository;
            _questionVersionAnswersRepository = questionVersionAnswersRepository;
            _questionVersionRecommendationsRepository = questionVersionRecommendationsRepository;
            _subQuestionVersionsRepository = subQuestionVersionsRepository;
            _mapper = mapper;
        }

        public async Task<Response<QuestionFormDTO>> Handle(
            CreateQuestionRequest request,
            CancellationToken cancellationToken)
        {
            Question question = new Question(request.IsActive);
            question = await _questionRepository.InsertAsync(question);

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
                request.Version.RequireValidation);

            questionVersion = await _questionVersionRepository.InsertAsync(questionVersion);

            question.SetVersion(questionVersion.Id);
            question = await _questionRepository.UpdateAsync(question);

            if (request.Version != null)
            {
                if (request.Version.Answers != null)
                {
                    foreach (int? answer in request.Version.Answers.Select(x => x.Id))
                    {
                        await _questionVersionAnswersRepository.InsertAsync(new QuestionVersionAnswers(questionVersion.Id, answer.Value));
                    }
                }
            }

            if (request.Version != null)
            {
                if (request.Version.Recommendations != null)
                {
                    foreach (int? recommendation in request.Version.Recommendations.Select(x => x.Id))
                    {
                        await _questionVersionRecommendationsRepository.InsertAsync(new QuestionVersionRecommendations(questionVersion.Id, recommendation.Value));
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

            question = await _questionRepository.GetByIdWithVersions(question.Id) ?? question;

            return new Response<QuestionFormDTO>(_mapper.Map<QuestionFormDTO>(question));
        }
    }
}
