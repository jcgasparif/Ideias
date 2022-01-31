using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class ReuniaoMap : IEntityTypeConfiguration<ReuniaoModel>
    {
        public void Configure(EntityTypeBuilder<ReuniaoModel> builder)
        {
            builder.ToTable("Reuniao", "Ideia");

            builder.Property(e => e.Data).HasColumnType("datetime");

            builder.Property(e => e.IdeiaId).HasColumnName("IdeiaID");

            builder.HasOne(d => d.Ideia)
                .WithMany(p => p.Reuniao)
                .HasForeignKey(d => d.IdeiaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reuniao_Ideias");
        }
    }
}