using EGAIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EGAIP.API.a_p_i
{
    public class UserAPI : IUserAPI
    {
        private readonly HttpClient _httpClient;

        public UserAPI(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<OutLoginUserModel> SendUserToLogin(LoginUserModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("ApiService/Controllers/User", model);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<OutLoginUserModel>();
        }
    }
}
