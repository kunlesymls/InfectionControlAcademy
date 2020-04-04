using Microsoft.AspNetCore.Identity;

namespace Academy.Models.Core
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
