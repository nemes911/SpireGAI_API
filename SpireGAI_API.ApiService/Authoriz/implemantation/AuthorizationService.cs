using SpireGAI_API.ApiService.Authoriz.Interface;
using Npgsql;
using SpireGAI_API.ApiService.Authoriz.Models;


namespace SpireGAI_API.ApiService.Authoriz.implemantation
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly string _connectionstring;

        public AuthorizationService(IConfiguration configuration) => _connectionstring = configuration.GetConnectionString("DefaultConnection");

        public async Task<OutLoginUserModel> AuthorizationAsync(LoginUserModel request) 
        {
            await using var conn = new NpgsqlConnection(_connectionstring);

            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand("SELECT gai.check_user(@user, @pass)", conn);

            cmd.Parameters.AddWithValue("user", request.name);
            cmd.Parameters.AddWithValue("password", request.password);

            var result = (bool)await cmd.ExecuteScalarAsync();

            return new OutLoginUserModel
            {
                name = request.name,
                role = "random"
            };
        }
    }
}
