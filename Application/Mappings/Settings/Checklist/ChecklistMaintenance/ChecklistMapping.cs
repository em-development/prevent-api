using AutoMapper;
using DTO.Settings.Checklist.ChecklistMaintenance;

namespace Application.Mappings.Settings.Checklist.ChecklistMaintenance
{
    public class ChecklistMapping : Profile
    {
        public ChecklistMapping()
        {
            CreateMap<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist, ChecklistDTO>()
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Title.Value : string.Empty))
                .ForMember(dto => dto.Key, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Key.Value : string.Empty))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0));

            CreateMap<Domain.Entities.Settings.Checklist.ChecklistMaintenance.Checklist, ChecklistFormDTO>()
                .ForMember(dto => dto.Title, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Title.Value : string.Empty))
                .ForMember(dto => dto.Key, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Key.Value : string.Empty))
                .ForMember(dto => dto.VersionId, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version.Version : 0))
                .ForMember(dto => dto.Version, x => x.MapFrom(
                    ent => ent.Version != null ? ent.Version : null));

        }
    }
}
