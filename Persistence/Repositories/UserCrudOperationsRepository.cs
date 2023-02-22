using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserCrudOperationsRepository : IUserCrudOperationsRepository
    {
        private readonly IConfiguration _configuration;

        public UserCrudOperationsRepository(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public async Task DeleteUser(int id)
        {
            string storedProcedure = "dbo.spUser_Delete";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            await connection.ExecuteAsync(storedProcedure, new { Id = id });
            
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            string connectionId = "Default";
            string storedProcedure = "dbo.spUser_Get";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await connection.QueryAsync<UserModel>(storedProcedure);  
             
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetUserById(int id)
        {
            string storedProcedure = "dbo.spUser_Get";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            return await connection.QueryAsync<UserModel>(storedProcedure, new {Id = id});
           //throw new NotImplementedException();
        }

        public async Task InsertUser(UserModel user)
        {
            string storedProcedure = "dbo.spUser_Insert";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            await connection.ExecuteAsync(storedProcedure, new {user.FirstName, user.LastName});
            //throw new NotImplementedException();
        }
    }
}
