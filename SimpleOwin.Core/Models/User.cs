using Microsoft.AspNet.Identity;

namespace SimpleOwin.Core.Models
{
    public class User : IUser<long>
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
    }
}