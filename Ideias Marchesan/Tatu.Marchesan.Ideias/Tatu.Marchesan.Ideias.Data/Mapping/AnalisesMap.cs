using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class AnalisesMap : IEntityTypeConfiguration<AnalisesModel>
    {
        public void Configure(EntityTypeBuilder<AnalisesModel> builder)
        {
            builder.ToTable("Analises", "Ideia");

            builder.Property(e => e.AspNetUsersId)
                    .IsRequired()
                    .HasColumnName("AspNetUsersID")
                    .HasMaxLength(450);

            builder.Property(e => e.DataAnalise).HasColumnType("date");

            builder.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(2000);

            builder.Property(e => e.IdeiaId).HasColumnName("IdeiaID");

            builder.Property(e => e.SequenciaAnalise).HasColumnName("SequenciaAnalise").HasColumnType("int");

            builder.Property(e => e.RelevanciaId).HasColumnName("RelevanciaID");

            builder.HasOne(d => d.Ideia)
                    .WithMany(p => p.Analises)
                    .HasForeignKey(d => d.IdeiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Analises_Ideias");

            builder.HasOne(d => d.Relevancia)
                    .WithMany(p => p.Analises)
                    .HasForeignKey(d => d.RelevanciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}