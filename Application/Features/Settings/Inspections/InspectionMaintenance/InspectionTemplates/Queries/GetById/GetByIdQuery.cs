using Application.Wrappers;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using MediatR;

namespace Application.Features.Settings.Inspections.InspectionMaintenance.InspectionTemplates.Queries.GetById
{
    public class GetByIdQuery : IRequest<Response<InspectionTemplateFormDTO>>
    {
        public int Id { get; set; }
    }
}