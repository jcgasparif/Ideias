namespace Softsige.Ideias.Domain.Entities.Models
{
    public partial class RoleClaimModel : EntityModel<int>
    {
        public string RoleName { get; set; }
        public string ClaimValue { get; set; }
    }
}