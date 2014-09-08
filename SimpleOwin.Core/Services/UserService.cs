using SimpleOwin.Core.Models;

namespace SimpleOwin.Core.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GetUserByUsername(string username);
    }
}
