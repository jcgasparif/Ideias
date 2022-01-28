using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
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
