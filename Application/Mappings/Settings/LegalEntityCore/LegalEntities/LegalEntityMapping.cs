using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using DTO.Settings.LegalEntityCore.LegalEntities;

namespace Application.Mappings.Settings.LegalEntityCore.LegalEntities
{
    public class LegalEntityMapping : Profile
    {
        public LegalEntityMapping()
        {
            CreateMap<LegalEntity, LegalEntityDTO>()
                .ForMember(dto => dto.Name, x => x.MapFrom(
                    ent => ent.Name == null ? null : ent.Name.Value))
                .ForMember(dto => dto.CodeEntity, x => x.MapFrom(
                    ent => ent.CodeEntity == null ? null : ent.CodeEntity.Value))
                .ForMember(dto => dto.TypeId, x => x.MapFrom(
                    ent => ent.LegalEntityTypeId));
        }

    }
}