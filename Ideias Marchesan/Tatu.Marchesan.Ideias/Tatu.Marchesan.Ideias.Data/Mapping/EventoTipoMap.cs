﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tatu.Marchesan.Ideias.Domain.Entities.Models;

namespace Tatu.Marchesan.Ideias.Infrastructure.Mapping
{
    public class EventoTipoMap : IEntityTypeConfiguration<EventoTipoModel>
    {
        public void Configure(EntityTypeBuilder<EventoTipoModel> builder)
        {
            builder.ToTable("EventoTipo", "Ideia");

            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}