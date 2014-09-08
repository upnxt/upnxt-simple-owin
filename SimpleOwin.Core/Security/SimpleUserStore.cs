using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleOwin.Core.Models;
using SimpleOwin.Core.Services;

namespace SimpleOwin.Core.Security
{
    public class SimpleUserStore<T> : IUserStore<T, long> where T : User
    {
        private readonly IUserService _userService;

        public SimpleUserStore(IUserService userService)
        {
            _userService = userService;
        }

        public System.Threading.Tasks.Task CreateAsync(T user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteAsync(T user)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<T> FindByIdAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<T> FindByNameAsync(string userName)
        {
            var task = Task<T>.Run(() =>
            {
                return (T)_userService.GetUserByUsername(userName);
            });

            return task;
        }

        public System.Threading.Tasks.Task UpdateAsync(T user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}