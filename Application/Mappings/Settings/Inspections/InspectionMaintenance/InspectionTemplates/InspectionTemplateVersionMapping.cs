using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionTemplates;
using DTO.Settings.Checklist.ChecklistMaintenance;
using DTO.Settings.PropertyCore.Properties;
using Domain.Enums.Settings.Entities;

namespace Application.Mappings.Settings.Inspections.InspectionMaintenance.InspectionTemplates
{
    public class InspectionTemplateVersionsMapping : Profile
    {
        public InspectionTemplateVersionsMapping()
        {
            CreateMap<InspectionTemplateVersion, InspectionTemplateVersionDTO>()
                 .ForMember(dto => dto.Title, x => x.MapFrom(
                     ent => ent.Title.Value))
                 .ForMember(dto => dto.InspectionTemplateId, x => x.MapFrom(
                     ent => ent.InspectionTemplateId))
                 .ForMember(dto => dto.Version, x => x.MapFrom(
                     ent => ent.Version))
                 .ForMember(output => output.Checklists, x => x.MapFrom(
                        input => input.InspectionTemplateVersionChecklists != null ?
                            input.InspectionTemplateVersionChecklists.Select(i => new ChecklistVersionDTO
                            {
                                Id = i.Checklist.VersionId.Value,
                                Title = i.Checklist.Version.Title.Value,
                                ChecklistId = i.Checklist.Id,
                                Key = i.Checklist.Version.Key.Value,
                                Version = i.Checklist.Version.Version
                            }).ToArray() :
                            null))
                 .ForMember(output => output.PropertyTypes, x => x.MapFrom(
                        input => input.InspectionTemplateVersionPropertyTypes != null ?
                            input.InspectionTemplateVersionPropertyTypes
                                .Select(i => (PropertyTypeEnum)i.PropertyType.Id).ToArray() :
                            null))
                 .ReverseMap();

        }
    }
}