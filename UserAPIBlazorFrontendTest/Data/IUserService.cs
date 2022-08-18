using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> ReadUser(int input);
    }
}