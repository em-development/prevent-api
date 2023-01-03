using Adapters.Repositories.Settings.Users;
using Application.Exceptions.Common;
using Application.Wrappers;
using AutoMapper;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.GetById
{
    internal class GetByIdHandler : IRequestHandler<GetByIdQuery, Response<UserFormDto>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUsersProfilesRepository _usersProfilesRepository;
        private readonly IUsersLegalEntitiesRepository _usersLegalEntitiesRepository;
        private readonly IMapper _mapper;

        public GetByIdHandler(
            IUsersRepository usersRepository,
            IUsersProfilesRepository usersProfilesRepository,
            IUsersLegalEntitiesRepository usersLegalEntitiesRepository,
            IMapper mapper
        )
        {
            _usersRepository = usersRepository;
            _usersProfilesRepository = usersProfilesRepository;
            _usersLegalEntitiesRepository = usersLegalEntitiesRepository;
            _mapper = mapper;
        }

        public async Task<Response<UserFormDto>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetByIdAsync(query.Id);

            if (user == null)
            {
                throw new NotFoundException(
                    "api-entity-user",
                    ("api-entity-user-field-id", query.Id));
            }

            var userDto = _mapper.Map<UserFormDto>(user);

            userDto.LegalEntityIds = await _usersLegalEntitiesRepository.GetLegalEntitiesByUserId(user.Id);
            userDto.UserProfileIds = await _usersProfilesRepository.GetUsersProfilesByUserId(user.Id);

            return new Response<UserFormDto>(userDto);
        }
    }
}