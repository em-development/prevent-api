using AutoMapper;
using Domain.Compacts.Settings.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Application.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionCompactMapping : Profile
    {
        public InspectionCompactMapping()
        {
            CreateMap<CompactInspection, CompactInspectionDTO>();
        }
    }
}
