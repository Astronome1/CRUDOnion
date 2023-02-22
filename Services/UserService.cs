
using Contracts;
using Domain.Repositories;
using Mapster;

namespace Services
{
    internal sealed class UserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager= repositoryManager;
        }

        public async Task<IEnumerable<UserInfoDto>> GetAllUsers()
        {
            var users = _repositoryManager.UserCrudOperationsRepository.GetAllUsers();
            var userinfodto = users.Adapt<IEnumerable<UserInfoDto>>();
            return userinfodto;
        }

        public async Task<UserInfoDto> GetSpecificUser(int id)
        {
            var specificUser = _repositoryManager.UserCrudOperationsRepository.GetUserById(id);
            if (specificUser == null)
            {
                throw new ArgumentNullException(nameof(specificUser));
            }
            
            var specificUserDto = specificUser.Adapt<UserInfoDto>();
            return specificUserDto;
        }
            
    }
}
