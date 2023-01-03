using Adapters.Context;
using Adapters.Repositories.Files;
using Adapters.Repositories.Settings.Checklist.RecommendationsCore.Recommendations;
using Adapters.Services.BaseLogs;
using Adapters.Services.Files;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.BaseLogs;
using Domain.Entities.Files;
using Domain.Entities.Settings.Checklist.RecommendationsCore.Recommendations;
using Domain.Enums.Files;
using Domain.Enums.Settings.Checklist.RecommendationsCore.Recommendations;
using DTO.Files;
using DTO.Settings.Checklist.RecommendationsCore.Recommendations;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Settings.Checklist.RecommendationsCore.Recommendations.Commands.CreateRecommendation
{
    internal class CreateRecommendationHandler : IRequestHandler<CreateRecommendationRequest, Response<RecommendationFormDTO>>
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

        public CreateRecommendationHandler(
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
            CreateRecommendationRequest request,
            CancellationToken cancellationToken)
        {
            Recommendation recommendation = new Recommendation(request.IsActive);
            recommendation = await _recommendationRepository.InsertAsync(recommendation);

            RecommendationVersion recommendationVersion = new RecommendationVersion(
                recommendation.Id,
                request.Version.Title,
                request.Version.Description, 
                request.Version.DueDateText,
                RecommendationVersionStatusEnum.PENDING, 
                0
            );

            recommendationVersion = await _recommendationVersionRepository.InsertAsync(recommendationVersion);

            foreach (var attachmentDto in request.Version?.Attachments)
            {
                attachmentDto.Guid = Guid.NewGuid().ToString();

                var attachment = new Attachment(
                    attachmentDto.Guid, 
                    attachmentDto.FileName, 
                    attachmentDto.ContentType, 
                    _configuration.GetSection("S3:Bucket").Value);

                await _attachmentRepository.InsertAsync(attachment);

                RecommendationAttachment recommendationAttachment = new RecommendationAttachment();
                recommendationAttachment.SetAttachmentId(attachment.Id);
                recommendationAttachment.SetRecommendationVersionId(recommendationVersion.Id);

                await _recommendationAttachmentRepository.InsertAsync(recommendationAttachment);

                _fileStorageService.AddFileToSchedule(attachmentDto, TypeAwsScheduleActionEnum.UPLOAD);
            }

            recommendation.SetVersion(recommendationVersion.Id);
            recommendation = await _recommendationRepository.UpdateAsync(recommendation);

            if (request.Version != null)
            {
                if (request.Version.Issues != null)
                {
                    foreach (int? issue in request.Version.Issues.Select(x => x.Id))
                    {
                        RecommendationVersionIssue recommendationIssue = await _recommendationVersionIssuesRepository
                            .InsertAsync(new RecommendationVersionIssue(recommendationVersion.Id, issue.Value));

                        await _logService.LINKS_SETTINGS_RECOMMENDATION_ISSUE(recommendationIssue);
                    }
                }
            }

            recommendation = await _recommendationRepository.GetByIdWithVersions(recommendation.Id) ?? recommendation;

            await _logService.CREATES_SETTINGS_RECOMMENDATION(recommendation);

            return new Response<RecommendationFormDTO>(_mapper.Map<RecommendationFormDTO>(recommendation));
        }
    }
}
