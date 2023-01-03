using AutoMapper;
using Domain.Entities.Settings.Inspections.InspectionMaintenance.Inspections;
using DTO.Settings.Inspections.InspectionMaintenance.InspectionProperties;
using DTO.Settings.Inspections.InspectionMaintenance.Inspections;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;

namespace Application.Mappings.Settings.Inspections.InspectionMaintenance.Inspections
{
    public class InspectionMapping : Profile
    {
        public InspectionMapping()
        {
            CreateMap<Inspection, InspectionDTO>()
                .ForMember(dto => dto.StatusId, x => x.MapFrom(
                    ent => ent.StatusId))
                .ForMember(dto => dto.InspectorId, x => x.MapFrom(
                    ent => ent.InspectorId))
                .ForMember(dto => dto.CoverageBegin, x => x.MapFrom(
                    ent => ent.CoverageBegin.Value))
                .ForMember(dto => dto.CoverageEnd, x => x.MapFrom(
                    ent => ent.CoverageEnd.Value))
                .ForMember(dto => dto.CoveragePremium, x => x.MapFrom(
                    ent => ent.CoveragePremium))
                .ForMember(dto => dto.IsHighRisk, x => x.MapFrom(
                    ent => ent.IsHighRisk))
                .ForMember(dto => dto.TemplateVersionId, x => x.MapFrom(
                    ent => ent.TemplateVersionId))
                .ForMember(output => output.PropertyCoverages, x => x.MapFrom(
                        input => input.InspectionPropertyCoverages != null ?
                            input.InspectionPropertyCoverages.Select(i => new InspectionPropertyCoverageDTO
                            {
                                Id = i.Id,
                                Coverage = i.Coverage.Value,
                                CoverageId = i.CoverageId,
                                Value = i.Value
                            }).ToArray() :
                            null))
                .ForMember(output => output.Buildings, x => x.MapFrom(
                        input => input.InspectionPropertyBuildings != null ?
                            input.InspectionPropertyBuildings.Select(i => new InspectionPropertyBuildingDTO
                            {
                                Id = i.Id,
                                BuildingPattern = i.BuildingPattern.Value,
                                Measures = i.Measures,
                                BuildingPatternRate = i.BuildingPatternRate,
                                Description = i.Description.Value
                            }).ToArray() :
                            null))
                .ForMember(output => output.Responsables, x => x.MapFrom(
                        input => input.InspectionResponsables != null ?
                            input.InspectionResponsables.Select(i => new LegalEntityContactDTO
                            {
                                Id = i.Id,
                                Name = i.LegalEntityContact.Name.Value,
                                Type = i.LegalEntityContact.LegalEntityContactTypeId,
                                Email = i.LegalEntityContact.Email.Value
                            }).ToArray() :
                            null))
                .ForMember(dto => dto.InspectionSchedule, x => x.MapFrom(
                    ent => ent.InspectionSchedule))
                .ReverseMap();
                

            CreateMap<Inspection, InspectionFormDTO>()
                .ForMember(dto => dto.StatusId, x => x.MapFrom(
                    ent => ent.StatusId))
                .ForMember(dto => dto.Inspector, x => x.MapFrom(
                    ent => ent.Inspector))
                .ForMember(dto => dto.Property, x => x.MapFrom(
                    ent => ent.Property))
                .ForMember(dto => dto.CoverageBegin, x => x.MapFrom(
                    ent => ent.CoverageBegin.Value))
                .ForMember(dto => dto.CoverageEnd, x => x.MapFrom(
                    ent => ent.CoverageEnd.Value))
                .ForMember(dto => dto.CoveragePremium, x => x.MapFrom(
                    ent => ent.CoveragePremium))
                .ForMember(dto => dto.IsHighRisk, x => x.MapFrom(
                    ent => ent.IsHighRisk))
                .ForMember(dto => dto.TemplateVersion, x => x.MapFrom(
                    ent => ent.InspectionTemplateVersion))
                .ForMember(output => output.PropertyCoverages, x => x.MapFrom(
                        input => input.InspectionPropertyCoverages != null ?
                            input.InspectionPropertyCoverages.Select(i => new InspectionPropertyCoverageDTO
                            {
                                Id = i.Id,
                                Coverage = i.Coverage.Value,
                                CoverageId = i.CoverageId,
                                Value = i.Value
                            }).ToArray() :
                            null))
                .ForMember(output => output.Buildings, x => x.MapFrom(
                        input => input.InspectionPropertyBuildings != null ?
                            input.InspectionPropertyBuildings.Select(i => new InspectionPropertyBuildingDTO
                            {
                                Id = i.Id,
                                BuildingPattern = i.BuildingPattern.Value,
                                Measures = i.Measures,
                                BuildingPatternRate = i.BuildingPatternRate,
                                Description = i.Description.Value
                            }).ToArray() :
                            null))
                .ForMember(output => output.Responsables, x => x.MapFrom(
                        input => input.InspectionResponsables != null ?
                            input.InspectionResponsables.Select(i => new LegalEntityContactDTO
                            {
                                Id = i.LegalEntityContact.Id,
                                Name = i.LegalEntityContact.Name.Value,
                                Type = i.LegalEntityContact.LegalEntityContactTypeId,
                                Email = i.LegalEntityContact.Email.Value
                            }).ToArray() :
                            null))
                .ForMember(dto => dto.InspectionSchedule, x => x.MapFrom(
                    ent => ent.InspectionSchedule))
                .ReverseMap();

        }
    }
}
