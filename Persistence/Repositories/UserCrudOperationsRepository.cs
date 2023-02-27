using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistence.Repositories
{
    public class UserCrudOperationsRepository : IUserCrudOperationsRepository
    {
        private readonly IConfiguration _configuration;

        public UserCrudOperationsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task DeleteUser(int id)
        {
            string storedProcedure = "dbo.spUser_Delete";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            DynamicParameters parameters= new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            string connectionId = "Default";
            string storedProcedure = "dbo.spUser_GetAll";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await connection.QueryAsync<UserModel>(storedProcedure);  
             
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetUserById(int Id)
        {
            string storedProcedure = "dbo.spUser_Get";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id, DbType.Int32);
            return await connection.QueryAsync<UserModel>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
           //throw new NotImplementedException();
        }

        public async Task InsertUser(UserModel user)
        {
            string storedProcedure = "dbo.spUser_Insert";
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            DynamicParameters parameters= new DynamicParameters();
            parameters.Add("@FirstName", user.FirstName, DbType.String);
            parameters.Add("@LastName", user.LastName, DbType.String);

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
           
            //throw new NotImplementedException();
        }
    }
}
