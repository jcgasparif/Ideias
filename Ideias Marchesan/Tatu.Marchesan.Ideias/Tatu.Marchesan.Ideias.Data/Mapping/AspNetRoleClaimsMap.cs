using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class AspNetRoleClaimsMap : IEntityTypeConfiguration<AspNetRoleClaims>
    {
        public void Configure(EntityTypeBuilder<AspNetRoleClaims> builder)
        {
            builder.Property(e => e.RoleId)
                .IsRequired()
                .HasMaxLength(450);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.AspNetRoleClaims)
                .HasForeignKey(d => d.RoleId);
        }
    }
}
