using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class RelevanciasMap : IEntityTypeConfiguration<RelevanciasModel>
    {
        public void Configure(EntityTypeBuilder<RelevanciasModel> builder)
        {
            builder.ToTable("Relevancias", "Ideia");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}