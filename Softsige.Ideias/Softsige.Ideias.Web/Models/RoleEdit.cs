using Microsoft.AspNetCore.Identity;

namespace Softsige.Ideias.App.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public AppUser Member { get; set; }
    }
}