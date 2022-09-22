using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web.Http;
using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private string token;
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

        public async Task<List<User>> GetAllUsersAuth()
        {
            try
            {
                using (HttpClient httpClient2 = new())
                {
                    httpClient2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    return await httpClient2.GetFromJsonAsync<List<User>>("https://localhost:7275/api/User/GetAllUsersAuth");
                }
            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
        }

        public async Task<string> Login(string username, string password)
        {
            try
            {
                token = await httpClient.GetStringAsync($"https://localhost:7275/api/User/login?username={username}&password={password}");
                return token;
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }
    }
}