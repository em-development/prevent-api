using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Application.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionChecklistsMapping : Profile
    {
        public InspectionTemplateVersionChecklistsMapping()
        {
            CreateMap<InspectionTemplateVersionChecklists, InspectionTemplateVersionChecklistsDTO>();
        }

    }
}
