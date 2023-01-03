using Adapters.Repositories.Settings.Users;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Users;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetInspectors
{
    internal class GetInspectorsHandler : IRequestHandler<GetInspectorsQuery, Response<IEnumerable<UserDto>>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public GetInspectorsHandler(
            IUsersRepository usersRepository,
            IMapper mapper
            )
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UserDto>>> Handle(
            GetInspectorsQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<User>? inspectors = await _usersRepository.GetInspectorsByLegalEntityId(query.Id);

            IEnumerable<UserDto>? inspectorsDTO = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(inspectors);

            return new(inspectorsDTO);
        }
    }
}
