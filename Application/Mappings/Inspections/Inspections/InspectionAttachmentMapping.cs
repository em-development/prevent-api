using AutoMapper;
using Domain.Entities.Inspections.Inspections;
using DTO.Inspections.Inspections;

namespace Application.Mappings.Inspections.Inspections;

public class InspectionAttachmentMapping : Profile
{
    public InspectionAttachmentMapping()
    {
        CreateMap<InspectionAttachment, InspectionAttachmentDto>();
    }
}