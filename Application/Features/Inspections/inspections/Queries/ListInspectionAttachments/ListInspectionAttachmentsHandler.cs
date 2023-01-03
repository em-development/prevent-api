using Adapters.Repositories.Inspections.Inspections;
using Application.Wrappers;
using AutoMapper;
using DTO.Inspections.Inspections;
using MediatR;

namespace Application.Features.Inspections.inspections.Queries.ListInspectionAttachments
{
    internal class ListInspectionAttachmentsHandler : IRequestHandler<ListInspectionAttachmentsQuery, Response<IEnumerable<InspectionAttachmentDto>>>
    {
        private readonly IInspectionAttachmentRepository _inspectionAttachmentRepository;
        private readonly IMapper _mapper;

        public ListInspectionAttachmentsHandler(
            IInspectionAttachmentRepository inspectionAttachmentRepository,
            IMapper mapper
            )
        {
            _inspectionAttachmentRepository = inspectionAttachmentRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<InspectionAttachmentDto>>> Handle(
            ListInspectionAttachmentsQuery query,
            CancellationToken cancellationToken)
        {
            var inspectionAttachments = await _inspectionAttachmentRepository.ListByInspectionId(query.InspectionId);

            var inspectionAttachmentsDto = _mapper.Map<IEnumerable<InspectionAttachmentDto>>(inspectionAttachments);

            return new Response<IEnumerable<InspectionAttachmentDto>>(inspectionAttachmentsDto);
        }
    }
}
