using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;

namespace Application.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionScheduleMapping : Profile
    {
        public InspectionScheduleMapping()
        {
            CreateMap<InspectionSchedule, InspectionScheduleDTO>()
                .ForMember(dto => dto.Id, x => x.MapFrom(
                    ent => ent.Id))
                .ForMember(dto => dto.Date, x => x.MapFrom(
                    ent => ent.Date));

        }
    }
}
