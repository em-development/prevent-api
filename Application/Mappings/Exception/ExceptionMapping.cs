using AutoMapper;
using Domain.Exceptions.Base;
using DTO.Exceptions;

namespace Application.Mappings.Exception
{
    public class ExceptionMapping : Profile
    {
        public ExceptionMapping()
        {
            CreateMap<ExceptionDTO, BaseException>().ReverseMap();
        }
    }
}
