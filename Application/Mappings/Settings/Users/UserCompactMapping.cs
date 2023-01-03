using AutoMapper;
using Domain.Compacts.Settings.Users;
using DTO.Settings.Users;

namespace Application.Mappings.Settings.Users
{
    public class UserCompactMapping : Profile
    {
        public UserCompactMapping()
        {
            CreateMap<CompactUser, CompactUserDTO>()
               .ForMember(dto => dto.Avatar, x => x.MapFrom(
                   ent => ent.Avatar != null ? ent.Avatar.FileName : null));
        }
    }
}
