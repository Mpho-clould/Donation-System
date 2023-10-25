using Microsoft.AspNetCore.Identity;

namespace POE_PART1.Models
{
    public class AppUser:IdentityUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set;}
    }
}
