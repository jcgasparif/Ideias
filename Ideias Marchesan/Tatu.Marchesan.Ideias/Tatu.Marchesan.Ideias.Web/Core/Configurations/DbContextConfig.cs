using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tatu.Marchesan.Ideias.App.Core.Data;
using Tatu.Marchesan.Ideias.Infrastructure.Context;

namespace Tatu.Marchesan.Ideias.App.Core.Configurations
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConn = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<MarchesanIdeiasDbContext>(options =>
                options.UseSqlServer(defaultConn).EnableDetailedErrors().EnableSensitiveDataLogging());

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(defaultConn).EnableDetailedErrors().EnableSensitiveDataLogging());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(defaultConn).EnableDetailedErrors().EnableSensitiveDataLogging());

            return services;
        }
    }
}