using Adapters.Repositories.Files;
using Adapters.Repositories.Inspections.Inspections;
using Adapters.Services.Files;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Files;
using Domain.Entities.Inspections.Inspections;
using Domain.Enums.Files;
using DTO.Inspections.Inspections;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Inspections.inspections.Commands.SaveInspectionAttachments
{
    internal class SaveInspectionAttachmentsRequestHandler : IRequestHandler<SaveInspectionAttachmentsRequest,
        Response<IEnumerable<InspectionAttachmentDto>>>
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IInspectionAttachmentRepository _inspectionAttachmentRepository;
        private readonly IConfiguration _configuration;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public SaveInspectionAttachmentsRequestHandler(
            IAttachmentRepository attachmentRepository,
            IInspectionAttachmentRepository inspectionAttachmentRepository,
            IMapper mapper,
            IConfiguration configuration, IFileStorageService fileStorageService)
        {
            _attachmentRepository = attachmentRepository;
            _configuration = configuration;
            _fileStorageService = fileStorageService;
            _inspectionAttachmentRepository = inspectionAttachmentRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<InspectionAttachmentDto>>> Handle(
            SaveInspectionAttachmentsRequest request,
            CancellationToken cancellationToken)
        {
            foreach (var attachmentDto in request.Attachments)
            {
                attachmentDto.Guid = Guid.NewGuid().ToString();

                var attachment = new Attachment(
                    attachmentDto.Guid,
                    attachmentDto.FileName,
                    attachmentDto.ContentType,
                    _configuration.GetSection("S3:Bucket").Value);

                await _attachmentRepository.InsertAsync(attachment);

                var inspectionAttachment = new InspectionAttachment(attachment.Id, request.InspectionId);

                await _inspectionAttachmentRepository.InsertAsync(inspectionAttachment);

                _fileStorageService.AddFileToSchedule(attachmentDto, TypeAwsScheduleActionEnum.UPLOAD);
            }

            var inspectionAttachments =
                await _inspectionAttachmentRepository.ListByInspectionId(request.InspectionId);

            var inspectionAttachmentsDto = _mapper.Map<IEnumerable<InspectionAttachmentDto>>(inspectionAttachments);

            return new Response<IEnumerable<InspectionAttachmentDto>>(inspectionAttachmentsDto);
        }
    }
}