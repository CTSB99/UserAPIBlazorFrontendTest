using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using System.Web.Http;
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
            try
            {
                return await httpClient.GetFromJsonAsync<User>($"https://localhost:7275/api/User/ReadUser?id={userId}"); //Error is thrown here already
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task CreateUser(User user)
        {
            Console.WriteLine($"\n\n\n\n\n This is the new User: {user.Username} \n\n\n\n\n\n");

            using var response = await httpClient.PostAsJsonAsync("https://localhost:7275/api/User/CreateUser/", user);

            Console.WriteLine($"\n\n\n\n\n This is the response: {response} \n\n\n\n\n\n");
        }

        public async Task<bool> DeleteUser(int id)
        {
            var response = await httpClient.DeleteAsync($"https://localhost:7275/api/User/DeleteUser?id={id}");
            Console.WriteLine($"\n\n\n\n\n This is the response: {response.IsSuccessStatusCode} \n\n\n\n\n\n");
            return response.IsSuccessStatusCode;
        }
    }
}