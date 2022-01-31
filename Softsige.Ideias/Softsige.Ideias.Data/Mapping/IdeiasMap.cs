using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class IdeiasMap : IEntityTypeConfiguration<IdeiasModel>
    {
        public void Configure(EntityTypeBuilder<IdeiasModel> builder)
        {
            builder.ToTable("Ideias", "Ideia");

            builder.Property(e => e.Argumentos)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(e => e.AspNetUsersId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(e => e.DataInclusao).HasColumnType("datetime");

            builder.Property(e => e.DataSubAnalise).HasColumnType("date");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.DetalhesConcorrente)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.ProdutoExistente)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.StatusId).HasColumnName("StatusID");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Ideias)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ideias_Status");
        }
    }
}