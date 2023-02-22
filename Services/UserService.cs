
using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using System.Security.Principal;

namespace Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<UserInfoDto>> GetAllUsers()
        {
            var users = await _repositoryManager.UserCrudOperationsRepository.GetAllUsers();
            var userinfodto = users.Adapt<IEnumerable<UserInfoDto>>();
            return userinfodto;
        }

        public async Task<UserInfoDto> GetSpecificUser(int id)
        {
            var specificUser = await _repositoryManager.UserCrudOperationsRepository.GetUserById(id);
            if (specificUser == null)
            {
                throw new ArgumentNullException(nameof(specificUser));
            }

            var specificUserDto = specificUser.Adapt<UserInfoDto>();
            return specificUserDto;
        }

        public async Task<UserInfoDto> CreateUser(UserInfoDto user)
        {
            var account = user.Adapt<UserModel>();

            await _repositoryManager.UserCrudOperationsRepository.InsertUser(account);

            return account.Adapt<UserInfoDto>();
        }
        public async Task DeleteUser(int id)
        {
            //var userToBeDeleted = user.Adapt<UserModel>();

            await _repositoryManager.UserCrudOperationsRepository.DeleteUser(id);
        }

    }
}
