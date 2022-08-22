using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> ReadUser(int input);
        Task CreateUser(string firstname, string lastname, string username, string password);
        void DeleteUser(int id);
    }
}