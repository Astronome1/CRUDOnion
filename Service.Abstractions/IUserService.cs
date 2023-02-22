
using Contracts;

namespace Services
{
    public interface IUserService
    {
        Task<UserInfoDto> CreateUser(UserInfoDto user);
        Task DeleteUser(int id);
        Task<IEnumerable<UserInfoDto>> GetAllUsers();
        Task<UserInfoDto> GetSpecificUser(int id);
    }
}