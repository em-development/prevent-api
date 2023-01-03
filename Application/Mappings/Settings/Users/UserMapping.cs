using AutoMapper;
using Domain.Compacts.Settings.Users;
using Domain.Entities.Settings.Users;
using DTO.Settings.Users;

namespace Application.Mappings.Settings.Users
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<CompactUser, CompactUserDTO>();
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Name, x => x.MapFrom(
                    ent => ent.Name == null ? null : ent.Name.Value))
                .ForMember(dto => dto.Uid, x => x.MapFrom(
                    ent => ent.UId == null ? null : ent.UId.Value));

            CreateMap<User, UserFormDto>()
                .ForMember(dto => dto.Name, x => x.MapFrom(
                    ent => ent.Name == null ? null : ent.Name.Value))
                .ForMember(dto => dto.Uid, x => x.MapFrom(
                    ent => ent.UId == null ? null : ent.UId.Value));
        }
    }
}
