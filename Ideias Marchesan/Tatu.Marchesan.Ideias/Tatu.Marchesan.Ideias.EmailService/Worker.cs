using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tatu.Marchesan.Ideias.EmailService.Core.Context;
using Tatu.Marchesan.Ideias.EmailService.Core.Helpers;

namespace Tatu.Marchesan.Ideias.EmailService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DbmarchwebContext>();
                var logEnvioEmails = await dbContext.LogEnvioEmail.ToListAsync(stoppingToken);

                foreach (var item in logEnvioEmails.Where(x => !x.FgEmailEnviado))
                {
                    if (EmailHelper.SendEmail(item.EmailDest, item.Assunto, item.Mensagem))
                    {
                        var email = await dbContext.LogEnvioEmail.FindAsync(item.LogEnvioEmailId);
                        email.FgEmailEnviado = true;

                        dbContext.LogEnvioEmail.Update(email);
                        await dbContext.SaveChangesAsync(stoppingToken);
                    }

                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}