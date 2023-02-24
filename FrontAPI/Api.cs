using Contracts;
using Services;

namespace FrontAPI
{
    public static class Api
    {

        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users/{id}", GetSpecificUser);
            app.MapDelete("/Users", DeleteUser);
            app.MapPost("/Users", CreateUser);
        }

        public static async Task<IResult> GetUsers(IServiceManager serviceManager)
        {
            try
            {
                return Results.Ok(await serviceManager.UserService.GetAllUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> GetSpecificUser(int id, IServiceManager serviceManager)
        {
            try
            {
                var results = await serviceManager.UserService.GetSpecificUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex) 
            { 
            return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> DeleteUser(int id, IServiceManager serviceManager)
        {
            try
            {
                await serviceManager.UserService.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex) 
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> CreateUser(UserInfoDto user, IServiceManager serviceManager)
        {
            try
            {
                await serviceManager.UserService.CreateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            
        }
    }
}
