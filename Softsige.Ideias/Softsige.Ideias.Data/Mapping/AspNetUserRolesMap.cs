using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class AspNetUserRolesMap : IEntityTypeConfiguration<AspNetUserRoles>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRoles> builder)
        {
            builder.HasKey(e => new { e.UserId, e.RoleId });

            builder.HasOne(d => d.Role)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId);

            builder.HasOne(d => d.User)
                .WithMany(p => p.AspNetUserRoles)
                .HasForeignKey(d => d.UserId);

        }
    }
}
