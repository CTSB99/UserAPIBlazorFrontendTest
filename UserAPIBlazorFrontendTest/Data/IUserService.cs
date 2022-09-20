using Microsoft.AspNetCore.Mvc;
using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> ReadUser(int input);
        Task CreateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<List<User>> GetAllUsersAuth();
        Task<string> Login(string username, string password);
    }
}