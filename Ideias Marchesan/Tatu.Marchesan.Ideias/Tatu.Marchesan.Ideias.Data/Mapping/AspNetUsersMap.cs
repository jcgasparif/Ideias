using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class AspNetUsersMap : IEntityTypeConfiguration<AspNetUsers>
    {
        public void Configure(EntityTypeBuilder<AspNetUsers> builder)
        {
            builder.Property(e => e.Id).HasColumnName("Id").HasColumnType("nvarchar(450)").IsRequired();

            builder.Property(e => e.Email).HasMaxLength(256);

            builder.Property(e => e.NormalizedEmail).HasMaxLength(256);

            builder.Property(e => e.NormalizedUserName).HasMaxLength(256);

            builder.Property(e => e.UserName).HasMaxLength(256);

        }
    }
}
