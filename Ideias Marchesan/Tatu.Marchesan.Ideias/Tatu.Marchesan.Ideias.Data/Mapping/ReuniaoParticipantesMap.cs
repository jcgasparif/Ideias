using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class ReuniaoParticipantesMap : IEntityTypeConfiguration<ReuniaoParticipantesModel>
    {
        public void Configure(EntityTypeBuilder<ReuniaoParticipantesModel> builder)
        {
            builder.ToTable("ReuniaoParticipantes", "Ideia");

            builder.Property(e => e.ReuniaoId).HasColumnName("ReuniaoID");

            builder.Property(e => e.UsuarioId)
                .IsRequired()
                .HasColumnName("UsuarioID")
                .HasMaxLength(450);

            builder.HasOne(d => d.Reuniao)
                .WithMany(p => p.ReuniaoParticipantes)
                .HasForeignKey(d => d.ReuniaoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReuniaoParticipantes_Reuniao");
        }
    }
}