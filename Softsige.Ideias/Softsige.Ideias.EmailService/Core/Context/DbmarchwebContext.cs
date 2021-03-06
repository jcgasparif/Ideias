// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Softsige.Ideias.EmailService.Core.Models;

namespace Softsige.Ideias.EmailService.Core.Context
{
    public partial class DbmarchwebContext : DbContext
    {
        public DbmarchwebContext()
        {
        }

        public DbmarchwebContext(DbContextOptions<DbmarchwebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogEnvioEmail> LogEnvioEmail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEnvioEmail>(entity =>
            {
                entity.Property(e => e.Assunto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DataHoraEnvio).HasColumnType("datetime");

                entity.Property(e => e.EmailDest)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailRemet)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdeiaId).HasColumnName("IdeiaID");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}