using Newtonsoft.Json;
using System.Text.Json;
using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public class UserService : IUserService
    {
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

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

        public async Task CreateUser(string firstname, string lastname, string username, string password)
        {
            User newUser = new();
            newUser.Firstname = firstname;
            newUser.Lastname = lastname;
            newUser.Username = username;
            newUser.Password = password;

            Console.WriteLine($"\n\n\n\n\n This is the new User 1: {newUser.Username} \n\n\n\n\n\n");

            using var response = await httpClient.PostAsJsonAsync("https://localhost:7275/api/User/CreateUser/", newUser);

            Console.WriteLine($"\n\n\n\n\n This is the response: {response} \n\n\n\n\n\n");
        }
    }
}