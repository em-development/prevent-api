using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntityContacts;
using DTO.Settings.LegalEntityCore.LegalEntityContacts;

namespace Application.Mappings.Settings.LegalEntityCore.LegalEntityContacts
{
    public class LegalEntityContactMapping : Profile
    {
        public LegalEntityContactMapping()
        {
            CreateMap<LegalEntityContact, LegalEntityContactDTO>()
                .ForMember(dto => dto.Name, x => x.MapFrom(
                    ent => ent.Name == null ? null : ent.Name.Value))
                .ForMember(dto => dto.Email, x => x.MapFrom(
                    ent => ent.Email == null ? null : ent.Email.Value))
                .ForMember(dto => dto.Type, x => x.MapFrom(
                    ent => ent.LegalEntityContactTypeId));
        }

    }
}