using System;
using System.Collections.Generic;
using cnet_POM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CedRentFIMAAPIPOM.Controllers;

namespace CedRentFIMAAPIPOM
{
    public class Startup
    {
        private const string ExceptionsOnStartup = "Startup";
        private const string ExceptionsOnConfigureServices = "ConfigureServices";
        private readonly Dictionary<string, List<Exception>> _exceptions;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._exceptions = new Dictionary<string, List<Exception>>
                           {
                             { ExceptionsOnStartup, new List<Exception>() },
                             { ExceptionsOnConfigureServices, new List<Exception>() },
                           };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            try
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                services.AddMemoryCache();

                services.Configure<IISOptions>(options => { options.ForwardClientCertificate = true; });

                services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

                string ambiente = Configuration.GetValue<string>("AppSettings:Ambiente");

                string usuarioDBEnv = Environment.GetEnvironmentVariable("BD_USERNAME");
                string passwordDBEnv = Environment.GetEnvironmentVariable("BD_PASSWORD");

                string cnnStr = String.Format(Configuration.GetConnectionString("DefaultConnection"), usuarioDBEnv, passwordDBEnv);

                services.AddDbContext<Models.ACContext>(options => options.UseSqlServer(
                   cnnStr
                   ));
                services.AddSingleton<IPathProvider, PathProvider>();
                services.AddDirectoryBrowser();
                services.AddPOM();
                services.AddControllers();
            }
            catch (Exception ex)
            {
                this._exceptions[ExceptionsOnConfigureServices].Add(ex);
                if (ex.InnerException != null)
                {
                    this._exceptions[ExceptionsOnConfigureServices].Add(ex.InnerException);
                }
                return;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (this._exceptions.Any(p => p.Value.Any()))
            {
                app.Run(
                  async context =>
                  {
                      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      context.Response.ContentType = "text/html";
                      string mensaje = string.Empty;
                      mensaje = string.Format("Cantidad de excepciones en {1}:{0}<BR>", this._exceptions.Count, Environment.MachineName);
                      foreach (var ex in this._exceptions)
                      {
                          foreach (var val in ex.Value)
                          {
                              mensaje += string.Format("{0}: {1}<BR>", ex.Key, val.Message);
                          }
                      }
                      await context.Response.WriteAsync(mensaje).ConfigureAwait(false);
                  });
                return;
            }
            app.UseHsts();
            app.UseStaticFiles();
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Logs")),
                RequestPath = "/Logs"
            });

            //POM
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UsePOM();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
