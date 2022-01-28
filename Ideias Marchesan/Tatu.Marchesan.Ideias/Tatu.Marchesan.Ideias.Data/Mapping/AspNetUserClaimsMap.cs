using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class AspNetUserClaimsMap : IEntityTypeConfiguration<AspNetUserClaims>
    {
        public void Configure(EntityTypeBuilder<AspNetUserClaims> builder)
        {
            builder.Property(e => e.UserId)
                   .IsRequired()
                   .HasMaxLength(450);

            builder.HasOne(d => d.User)
                .WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId);
        }
    }
}
