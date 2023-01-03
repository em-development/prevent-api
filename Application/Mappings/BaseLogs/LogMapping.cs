using Application.Services.Files;
using AutoMapper;
using Domain.Entities.BaseLogs;
using Domain.Entities.Files;
using DTO.BaseLogs;
using DTO.Files;

namespace Application.Mappings.BaseLogs
{
    public class LogMapping : Profile
    {
        public LogMapping()
        {
            CreateMap<Log, LogDTO>();

        }
    }
}