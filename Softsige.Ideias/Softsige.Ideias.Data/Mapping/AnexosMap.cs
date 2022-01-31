using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class AnexosMap : IEntityTypeConfiguration<AnexosModel>
    {
        public void Configure(EntityTypeBuilder<AnexosModel> builder)
        {
            builder.ToTable("Anexos", "Ideia");

            builder.Property(e => e.EventoTipoId).HasColumnName("EventoTipoID");

            builder.Property(e => e.IdeiaId).HasColumnName("IdeiaID");

            builder.Property(e => e.Path).HasColumnName("Path")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

            builder.Property(e => e.Descricao).HasColumnName("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

            builder.HasOne(d => d.EventoTipo)
                .WithMany(p => p.Anexos)
                .HasForeignKey(d => d.EventoTipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Anexos_EventoTipo");

            builder.HasOne(d => d.Ideia)
                .WithMany(p => p.Anexos)
                .HasForeignKey(d => d.IdeiaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Anexos_Ideias");
        }
    }
}