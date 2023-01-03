using AutoMapper;
using Domain.Entities.Core;
using DTO.Core.Menus;

namespace Application.Mappings.Core.Menus
{
    internal class MenuMapping : Profile
    {
        public MenuMapping()
        {
            CreateMap<Menu, MenuDto>()
                .ForMember(output => output.Children, x => x.MapFrom(
                    input => input.Children));
        }
    }
}