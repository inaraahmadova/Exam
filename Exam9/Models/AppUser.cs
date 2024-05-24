using Microsoft.AspNetCore.Identity;

namespace Exam9.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
