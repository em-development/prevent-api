using Adapters.Repositories.Settings.Users;
using Adapters.Services.Settings.Users;
using AutoMapper;
using Domain.Compacts.Settings.Users;
using DTO.Settings.Users;

namespace Application.Services.Settings.Users
{
    public sealed class UserService : IUserService
    {
        private readonly ICompactUserRepository _compactUserRepository;
        private readonly IMapper _mapper;

        public UserService(ICompactUserRepository userRepository, IMapper mapper)
        {
            _compactUserRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CompactUserDTO?> GetBySubjectIdAsync(string subjectId)
        {
            CompactUser? entity = await _compactUserRepository.GetBySubjectIdAsync(subjectId);
            return _mapper.Map<CompactUserDTO?>(entity);
        }

        public async Task<CompactUserDTO?> GetByEmailAsync(string email)
        {
            CompactUser? entity = await _compactUserRepository.GetByEmailAsync(email);
            return _mapper.Map<CompactUserDTO?>(entity);
        }
    }
}
