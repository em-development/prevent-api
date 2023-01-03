using AutoMapper;
using Domain.Entities.Settings.PropertyCore.Properties;
using DTO.Settings.PropertyCore.Properties;

namespace Application.Mappings.Settings.PropertyCore.Properties
{
    public class PropertyTypeMapping : Profile
    {
        public PropertyTypeMapping()
        {
            CreateMap<PropertyType, PropertyTypeDTO>()
                .ForMember(dto => dto.Description, x => x.MapFrom(
                    ent => ent.Description == null ? null : ent.Description.Value));
        }

    }
}