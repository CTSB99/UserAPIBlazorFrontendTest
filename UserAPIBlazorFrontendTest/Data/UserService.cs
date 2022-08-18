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

        public async Task<List<User>> GetAllUsers()
        {
            return await httpClient.GetFromJsonAsync<List<User>>("https://localhost:7275/api/User/GetAllUsers");
        }

        public async Task<User> ReadUser(int userId)
        {
            return await httpClient.GetFromJsonAsync<User>($"https://localhost:7275/api/User/ReadUser?id={userId}");
        }
    }
}