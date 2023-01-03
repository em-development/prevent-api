using AutoMapper;
using Domain.Entities.Settings.Countries;
using Domain.ValueObjects.General;
using Domain.ValueObjects.Settings.Countries;
using DTO.Settings.Countries;

namespace Application.Mappings.Settings.Countries
{
    public class CountryMapping : Profile
    {
        public CountryMapping()
        {
            string ClassName = typeof(CountryDTO).AssemblyQualifiedName ?? "";

            CreateMap<Country, CountryDTO>()
                 .ForMember(dto => dto.Description, x => x.MapFrom(
                     ent => ent.Description == null ? null : ent.Description.Value))
                 .ForMember(dto => dto.Lang, x => x.MapFrom(
                     ent => ent.Lang == null ? null : ent.Lang.Value));

            CreateMap<CountryDTO, Country>()
                 .ForMember(ent => ent.Description, x => x.MapFrom(
                     dto => dto.Description == null ? null : Description.CreateValid(dto.Description, ClassName)))
                 .ForMember(ent => ent.Lang, x => x.MapFrom(
                     dto => dto.Lang == null ? null : Lang.CreateValid(dto.Lang, ClassName)));
        }
    }
}