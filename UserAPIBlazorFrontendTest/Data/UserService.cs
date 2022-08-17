using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        public UserService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<List<User>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<List<User>>("https://localhost:7275/api/User/GetAllUsers");
        }
    }
}
