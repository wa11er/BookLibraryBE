using Microsoft.AspNetCore.Identity;

namespace BookLibraryBE.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
