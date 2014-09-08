using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleOwin.AuthConfig))]
namespace SimpleOwin
{
    public class AuthConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var cookieAuthOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                CookieHttpOnly = true,
                ExpireTimeSpan = TimeSpan.FromMinutes(60),
                SlidingExpiration = true,
                CookieSecure = CookieSecureOption.SameAsRequest,
                LoginPath = new PathString("/Account/Login")
            };

            app.UseCookieAuthentication(cookieAuthOptions);
        }
    }
}