using Application.Wrappers;
using AutoMapper;
using Domain.Exceptions.Base;
using DTO.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IMapper _mapper;

        public ExceptionFilter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void OnException(ExceptionContext context)
        {
            var exceptionDto = CreateExceptionDto(context);
            var statusCode = GetStatusCode(context);

            var response = new Response<object>(exceptionDto);

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }

        private static int GetStatusCode(ExceptionContext context)
        {
            return context.Exception is BaseException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;
        }

        private ExceptionDTO CreateExceptionDto(ExceptionContext context)
        {
            if (context.Exception is BaseException exception)
            {
                return _mapper.Map<ExceptionDTO>(exception);
            }
            else
            {
                return new ExceptionDTO("api-exception-internal-server-error");
            }
        }
    }
}
