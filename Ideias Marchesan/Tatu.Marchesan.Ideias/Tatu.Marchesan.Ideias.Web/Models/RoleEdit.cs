using Microsoft.AspNetCore.Identity;

namespace Tatu.Marchesan.Ideias.App.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public AppUser Member { get; set; }
    }
}