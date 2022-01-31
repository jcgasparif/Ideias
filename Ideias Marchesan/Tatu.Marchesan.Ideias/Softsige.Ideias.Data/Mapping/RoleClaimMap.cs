using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class RoleClaimMap : IEntityTypeConfiguration<RoleClaimModel>
    {
        public void Configure(EntityTypeBuilder<RoleClaimModel> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id");

            builder.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(e => e.ClaimValue)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}