using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Tatu.Marchesan.Ideias.App.Core.Data;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Repository;
using Tatu.Marchesan.Ideias.Domain.Interfaces.Service;
using Tatu.Marchesan.Ideias.Infrastructure.Context;
using Tatu.Marchesan.Ideias.Infrastructure.Repository;
using Tatu.Marchesan.Ideias.Services.Services;

namespace Tatu.Marchesan.Ideias.App.Core.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectConfig(this IServiceCollection services)
        {
            services.AddScoped<MarchesanIdeiasDbContext>();
            services.AddScoped<AppIdentityDbContext>();
            services.AddScoped<IComiteRepository, ComiteRepository>();
            services.AddScoped<IIdeiasRepository, IdeiasRepository>();
            services.AddScoped<IAnexosRepository, AnexosRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IRelevanciaRepository, RelevanciaRepository>();

            services.AddScoped<IComiteService, ComiteService>();
            services.AddScoped<IIdeiasService, IdeiasService>();
            services.AddScoped<IAnexosService, AnexosService>();
            services.AddScoped<IAnexosService, AnexosService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IRelevanciaService, RelevanciaService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }
    }
}