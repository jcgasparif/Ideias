using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class MensagensMap : IEntityTypeConfiguration<MensagensModel>
    {
        public void Configure(EntityTypeBuilder<MensagensModel> builder)
        {
            builder.ToTable("Mensagens", "Ideia");

            builder.Property(e => e.DataFim).HasColumnType("date");

            builder.Property(e => e.DataInicio).HasColumnType("date");

            builder.Property(e => e.MotivoMensagemId).HasColumnName("MotivoMensagemID");

            builder.HasOne(d => d.MotivoMensagem)
                .WithMany(p => p.Mensagens)
                .HasForeignKey(d => d.MotivoMensagemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensagens_MotivoMensagens");
        }
    }
}