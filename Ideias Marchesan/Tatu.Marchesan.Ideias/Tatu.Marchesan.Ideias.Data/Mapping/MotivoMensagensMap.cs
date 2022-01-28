using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class MotivoMensagensMap : IEntityTypeConfiguration<MotivoMensagensModel>
    {
        public void Configure(EntityTypeBuilder<MotivoMensagensModel> builder)
        {
            builder.ToTable("MotivoMensagens", "Ideia");

            builder.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}