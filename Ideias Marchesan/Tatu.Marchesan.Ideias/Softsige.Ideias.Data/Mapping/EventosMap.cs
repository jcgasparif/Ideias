using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Mapping
{
    public class EventosMap : IEntityTypeConfiguration<EventosModel>
    {
        public void Configure(EntityTypeBuilder<EventosModel> builder)
        {
            builder.ToTable("Eventos", "Ideia");

            builder.Property(e => e.Data).HasColumnType("datetime");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.EventoTipoId).HasColumnName("EventoTipoID");

            builder.HasOne(d => d.EventoTipo)
                .WithMany(p => p.Eventos)
                .HasForeignKey(d => d.EventoTipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Eventos_EventoTipo");
        }
    }
}