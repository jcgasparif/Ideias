using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
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