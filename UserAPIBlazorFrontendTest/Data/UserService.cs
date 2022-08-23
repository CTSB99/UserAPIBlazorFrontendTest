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
                var response = await httpClient.GetFromJsonAsync<User>($"https://localhost:7275/api/User/ReadUser?id={userId}"); //Error is thrown here already
                Console.WriteLine($"\n\n\n\n\n{response}\n\n\n\n\n");
                if (response == null)
                {
                    Console.WriteLine("\n\n\n\n\n LOLLOLO \n\n\n\n\n");
                    throw new Exception(message: "User Not Found");
                }

                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n\n\n\n\n ex.Message: {ex.Message}\n\n\n\n\n");
                return null;
            }
        }

        public async Task CreateUser(User user)
        {
            Console.WriteLine($"\n\n\n\n\n This is the new User 1: {user.Username} \n\n\n\n\n\n");

            using var response = await httpClient.PostAsJsonAsync("https://localhost:7275/api/User/CreateUser/", user);

            Console.WriteLine($"\n\n\n\n\n This is the response: {response} \n\n\n\n\n\n");
        }

        public void DeleteUser(int id)
        {
            httpClient.DeleteAsync($"https://localhost:7275/api/User/DeleteUser?id={id}");
        }
    }
}