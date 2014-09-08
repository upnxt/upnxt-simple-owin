using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SimpleOwin.Core.Models;
using SimpleOwin.Core.Services;


namespace SimpleOwin.Core.Security
{
    public interface ISimpleUserManager
    {
        Task<User> FindAsync(string userName, string password);
        Task SignInAsync(User user, bool isPersistent);
        void SignOut();
    }

    public class SimpleUserManager : UserManager<User, long>, ISimpleUserManager
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationManager _authenticationManager;

        public SimpleUserManager(IUserService userService, IAuthenticationManager authenticationManager)
            : base(new SimpleUserStore<User>(userService))
        {
            _userService = userService;
            _authenticationManager = authenticationManager;
        }

        public override Task<User> FindAsync(string userName, string password)
        {
            var task = Task<User>.Run(() =>
            {
                var user = _userService.Authenticate(userName, password);

                return user;
            });

            return task;
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            SignOut();

            var identity = await base.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public void SignOut()
        {
            _authenticationManager.SignOut();
        }
    }
}