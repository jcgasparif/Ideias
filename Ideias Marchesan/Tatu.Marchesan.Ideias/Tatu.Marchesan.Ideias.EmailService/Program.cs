using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Tatu.Marchesan.Ideias.EmailService.Core.Context;

namespace Tatu.Marchesan.Ideias.EmailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(options => options.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Information))
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>().Configure<EventLogSettings>(config =>
                    {
                        config.LogName = "Tatu Marchesan Ideias Email Service";
                        config.SourceName = "Tatu Marchesan Ideias Email Service Source";
                    });
                }).UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<DbmarchwebContext>();
                    optionsBuilder.UseSqlServer(hostContext.Configuration.GetSection("ConnectionStrings")
                        .GetSection("DefaultConnection").Value);
                    services.AddScoped(s => new DbmarchwebContext(optionsBuilder.Options));
                    services.AddHostedService<Worker>();
                });
    }
}