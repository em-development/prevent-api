using AutoMapper;
using Domain.Entities.Settings.PropertyCore.Properties;
using DTO.Settings.PropertyCore.Properties;

namespace Application.Mappings.Settings.PropertyCore.Properties
{
    public class PropertyMapping : Profile
    {
        public PropertyMapping()
        {
            CreateMap<Property, PropertyDTO>()
                .ForMember(dto => dto.Name, x => x.MapFrom(
                    ent => ent.Name == null ? null : ent.Name.Value))
                .ForMember(dto => dto.Address, x => x.MapFrom(
                    ent => ent.Address == null ? null : ent.Name.Value))
                .ForMember(dto => dto.Code, x => x.MapFrom(
                    ent => ent.Code == null ? null : ent.Code.Value));
        }

    }
}