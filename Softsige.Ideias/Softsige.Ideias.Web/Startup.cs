using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using Softsige.Ideias.App.Core.Configurations;
using WebMarkupMin.AspNet.Brotli;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore3;
using WebMarkupMin.Core;
using WebMarkupMin.NUglify;

namespace Softsige.Ideias.App
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add response caching service.
            services.AddResponseCaching();

            // Add WebMarkupMin services to the services container.
            services.AddWebMarkupMin(options =>
            {
                options.AllowMinificationInDevelopmentEnvironment = true;
                options.AllowCompressionInDevelopmentEnvironment = true;
            })
            .AddHtmlMinification(options =>
            {
                HtmlMinificationSettings settings = options.MinificationSettings;
                settings.RemoveRedundantAttributes = true;
                settings.RemoveHttpProtocolFromAttributes = true;
                settings.RemoveHttpsProtocolFromAttributes = true;

                options.CssMinifierFactory = new NUglifyCssMinifierFactory();
                options.JsMinifierFactory = new NUglifyJsMinifierFactory();
            })
            .AddHttpCompression(options =>
            {
                options.CompressorFactories = new List<ICompressorFactory>
                {
                    new BrotliCompressorFactory(new BrotliCompressionSettings { Level = 1 }),
                    new DeflateCompressorFactory(new DeflateCompressionSettings { Level = CompressionLevel.Fastest }),
                    new GZipCompressorFactory(new GZipCompressionSettings { Level = CompressionLevel.Fastest })
                };
            });

            services.AddIdentityConfiguration(Configuration);
            services.AddDbContextConfig(Configuration);
            services.AddMvcConfiguration();
            services.AddDependencyInjectConfig();
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = r =>
                {
                    var path = r.File.PhysicalPath;
                    if (path.EndsWith(".css") || path.EndsWith(".js") || path.EndsWith(".gif") ||
                        path.EndsWith(".jpg") || path.EndsWith(".png") || path.EndsWith(".svg") ||
                        path.EndsWith(".woff") || path.EndsWith(".woff2") || path.EndsWith(".svg"))
                    {
                        var maxAge = new TimeSpan(30, 0, 0, 0);
                        r.Context.Response.Headers.Append("Cache-Control", "max-age=" + maxAge.TotalSeconds.ToString("0"));
                    }
                }
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseGlobalizationConfig();
            app.UseResponseCaching();
            app.UseWebMarkupMin();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}