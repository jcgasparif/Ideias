using Microsoft.EntityFrameworkCore;
using System.Linq;
using Softsige.Ideias.Domain.Entities.Models;

namespace Softsige.Ideias.Infrastructure.Context
{
    public sealed class MarchesanIdeiasDbContext : DbContext
    {
        public MarchesanIdeiasDbContext(DbContextOptions<MarchesanIdeiasDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<AnalisesModel> Analises { get; set; }
        public DbSet<AnexosModel> Anexos { get; set; }
        public DbSet<EventoTipoModel> EventoTipo { get; set; }
        public DbSet<EventosModel> Eventos { get; set; }
        public DbSet<IdeiasModel> Ideias { get; set; }
        public DbSet<MensagensModel> Mensagens { get; set; }
        public DbSet<MotivoMensagensModel> MotivoMensagens { get; set; }
        public DbSet<RelevanciasModel> Relevancias { get; set; }
        public DbSet<ReuniaoModel> Reuniao { get; set; }
        public DbSet<ReuniaoParticipantesModel> ReuniaoParticipantes { get; set; }
        public DbSet<StatusModel> Status { get; set; }
        public DbSet<RoleClaimModel> RoleClaim { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ONDE NÃO TIVER SETADO VARCHAR E A PROPRIEDADE FOR DO TIPO STRING FICA VALENDO VARCHAR(VALOR)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties()
                     .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            // IMPL033: BUSCA OS MAPPPINGS DE UMA VEZ SÓ
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarchesanIdeiasDbContext).Assembly);

            //REMOVE DELETE CASCADE
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}