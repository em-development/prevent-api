using Adapters.Repositories.Files;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Adapters.Services.BaseLogs;
using Adapters.Services.Files;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Files;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Issues;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Enums.Files;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Settings.Checklist.RecommendationsCore.Issues;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.UpdateRecommendation
{
    public class
        UpdateRecommendationHandler : IRequestHandler<UpdateRecommendationRequest, Response<RecommendationFormDTO>>
    {
        private readonly IRecommendationRepository _recommendationRepository;
        private readonly IRecommendationVersionRepository _recommendationVersionRepository;
        private readonly IRecommendationVersionIssuesRepository _recommendationVersionIssuesRepository;
        private readonly IRecommendationAttachmentRepository _recommendationAttachmentRepository;
        private readonly IConfiguration _configuration;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public UpdateRecommendationHandler(
            IRecommendationRepository recommendationRepository,
            IRecommendationVersionRepository recommendationVersionRepository,
            IRecommendationVersionIssuesRepository recommendationVersionIssuesRepository,
            IRecommendationAttachmentRepository recommendationAttachmentRepository,
            IAttachmentRepository attachmentRepository,
            IFileStorageService fileStorageService,
            IConfiguration configuration,
            ILogService logService,
            IMapper mapper
        )
        {
            _recommendationRepository = recommendationRepository;
            _recommendationVersionRepository = recommendationVersionRepository;
            _recommendationVersionIssuesRepository = recommendationVersionIssuesRepository;
            _recommendationAttachmentRepository = recommendationAttachmentRepository;
            _fileStorageService = fileStorageService;
            _attachmentRepository = attachmentRepository;
            _configuration = configuration;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<Response<RecommendationFormDTO>> Handle(
            UpdateRecommendationRequest request,
            CancellationToken cancellationToken)
        {
            var recommendation = await _recommendationRepository.GetByIdAsync(request.Id);
            var currentRecommendationVersion = recommendation.Version;

            if (recommendation == null)
            {
                throw new NotFoundException("api-entity-recommendation",
                    ("api-entity-recommendation-field-id", request.Id)
                );
            }

            var recommendationIssues =
                await _recommendationVersionIssuesRepository.GetByRecommendationVersionId(currentRecommendationVersion
                    .Id);
            var sentIssues = request.Version!.Issues!.Select(x => x.Id).ToList();
            var issues = recommendationIssues.Select(x => x.IssueId).ToList();

            if (HasRecommendationModification(request, recommendation) ||
                request.Version.Attachments!.Any() ||
                HasRecommendationIssuesModification(sentIssues, issues))
            {
                currentRecommendationVersion = new RecommendationVersion(
                    recommendation.Id,
                    request.Version.Title,
                    request.Version.Description,
                    request.Version.DueDateText,
                    RecommendationVersionStatusEnum.PENDING,
                    request.Version.Version + 1);
                currentRecommendationVersion =
                    await _recommendationVersionRepository.InsertAsync(currentRecommendationVersion);

                currentRecommendationVersion.IncrementVersion(recommendation.Version?.Version ?? 0);
                currentRecommendationVersion.SetDescription(request.Version.Description);

                recommendation.SetVersion(currentRecommendationVersion);
                recommendation.SetIsActive(request.IsActive);

                await _recommendationRepository.UpdateAsync(recommendation);
            }

            if (request.Version.Attachments.Any())
            {
                foreach (var attachmentDto in request.Version?.Attachments)
                {
                    attachmentDto.Guid = Guid.NewGuid().ToString();

                    var attachment = new Attachment(
                        attachmentDto.Guid,
                        attachmentDto.FileName,
                        attachmentDto.ContentType,
                        _configuration.GetSection("S3:Bucket").Value);

                    await _attachmentRepository.InsertAsync(attachment);

                    var recommendationAttachment = new RecommendationAttachment();
                    recommendationAttachment.SetAttachmentId(attachment.Id);
                    recommendationAttachment.SetRecommendationVersionId(currentRecommendationVersion.Id);

                    await _recommendationAttachmentRepository.InsertAsync(recommendationAttachment);

                    _fileStorageService.AddFileToSchedule(attachmentDto, TypeAwsScheduleActionEnum.UPLOAD);
                }
            }
            else
            {
                //mudar version dos anexos para o novo recommendationVersion
                var recommendationAttachments = await _recommendationAttachmentRepository
                    .GetByRecommendationVersionId(recommendation.Version.Id);

                foreach (var item in recommendationAttachments)
                {
                    item.SetRecommendationVersionId(currentRecommendationVersion.Id);
                    await _recommendationAttachmentRepository.UpdateAsync(item);
                }
            }

            if (request.Version.Issues != null)
            {
                foreach (int? issue in request.Version.Issues.Select(x => x.Id))
                {
                    var recommendationIssue = await _recommendationVersionIssuesRepository
                        .InsertAsync(new RecommendationVersionIssue(currentRecommendationVersion.Id, issue.Value));

                    await _logService.LINKS_SETTINGS_RECOMMENDATION_ISSUE(recommendationIssue);
                }
            }

            recommendation = await _recommendationRepository.GetByIdWithVersions(recommendation.Id);

            await _logService.UPDATES_SETTINGS_RECOMMENDATION(recommendation);

            return new Response<RecommendationFormDTO>(_mapper.Map<RecommendationFormDTO>(recommendation));
        }

        private bool HasRecommendationModification(UpdateRecommendationRequest request, Recommendation recommendation)
        {
            if (request.Version.Status !=
                (RecommendationVersionStatusEnum) recommendation.Version.RecommendationVersionStatusId ||
                request.Version.DueDateText != recommendation.Version.DueDateText.Value ||
                request.Version.Title != recommendation.Version.Title.Value ||
                request.Version.Description != recommendation.Version.Description.Value)
            {
                return true;
            }

            return false;
        }

        private static bool HasRecommendationIssuesModification(IReadOnlyCollection<int>? newIssues,
            IReadOnlyCollection<int>? issues)
        {
            if (newIssues?.Count != issues?.Count)
            {
                return true;
            }

            return newIssues != null && issues != null && (newIssues.Except(issues).Any() ||
                                                           issues.Except(newIssues).Any());
        }
    }
}