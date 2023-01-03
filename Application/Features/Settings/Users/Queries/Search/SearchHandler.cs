using Adapters.Repositories.Settings.Users;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.Users;
using DTO.Settings.Users;
using MediatR;

namespace Application.Features.Settings.Users.Queries.Search
{
    internal class SearchHandler : IRequestHandler<SearchQuery, PagedResponse<IEnumerable<UserDto>>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public SearchHandler(
            IUsersRepository usersRepository,
            IMapper mapper
            )
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<UserDto>>> Handle(
            SearchQuery query,
            CancellationToken cancellationToken)
        {
            var users = _usersRepository.SearchToDashboard(
                filter: query.Filter,
                current: query.Current,
                limit: query.Limit,
                orderDirection: query.OrderDirection,
                orderBy: query.OrderBy
            );

            return await users.Paginate<User, UserDto>(query.Current, query.Limit, _mapper);
        }
    }
}