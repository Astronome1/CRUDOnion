using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserCrudOperationsRepository
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<IEnumerable<UserModel>> GetUserById(int id);
        Task InsertUser(UserModel user);    
        Task DeleteUser(int id);
    }
}
