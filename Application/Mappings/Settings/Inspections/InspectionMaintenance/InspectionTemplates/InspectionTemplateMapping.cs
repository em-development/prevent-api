using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;

namespace Application.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateMapping : Profile
    {
        public InspectionTemplateMapping()
        {
            CreateMap<InspectionTemplate, InspectionTemplateDTO>()
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Title.Value : string.Empty))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0));

            CreateMap<InspectionTemplate, InspectionTemplateFormDTO>()
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Title.Value : string.Empty))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version : null));

        }
    }
}
