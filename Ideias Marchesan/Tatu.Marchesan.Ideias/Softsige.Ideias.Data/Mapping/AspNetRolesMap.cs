using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class AspNetRolesMap : IEntityTypeConfiguration<AspNetRoles>
    {
        public void Configure(EntityTypeBuilder<AspNetRoles> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(256);

            builder.Property(e => e.NormalizedName).HasMaxLength(256);
        }
    }
}
