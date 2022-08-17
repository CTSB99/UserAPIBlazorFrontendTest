using UserAPIBlazorFrontendTest.Models;

namespace UserAPIBlazorFrontendTest.Data
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
    }
}
