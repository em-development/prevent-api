using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntitySyncs;
using DTO.Settings.LegalEntityCore.LegalEntities;

namespace Application.Mappings.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntitySyncMapping : Profile
    {
        public LegalEntitySyncMapping()
        {
            CreateMap<LegalEntitySync, LegalEntityDTO>()
                .ForMember(dto => dto.Name, x => x.MapFrom(
                    ent => ent.Name == null ? null : ent.Name.Value))
                .ForMember(dto => dto.CodeEntity, x => x.MapFrom(
                    ent => ent.CodeEntity == null ? null : ent.CodeEntity.Value))
                .ForMember(dto => dto.TypeId, x => x.MapFrom(
                    ent => ent.LegalEntityTypeId));
        }

    }
}