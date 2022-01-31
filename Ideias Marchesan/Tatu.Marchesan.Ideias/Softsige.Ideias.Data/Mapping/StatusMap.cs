using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class StatusMap : IEntityTypeConfiguration<StatusModel>
    {
        public void Configure(EntityTypeBuilder<StatusModel> builder)
        {
            builder.ToTable("Status", "Ideia");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DescricaoProcesso)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}