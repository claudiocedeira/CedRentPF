using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using CedRentFIMA.Entidades;
using CedRentFIMAAPIPOM.Models;
using Microsoft.Extensions.Logging;

namespace CedRentFIMAAPIPOM.Controllers
{
    [ApiController]
    public class ACController : ControllerBase
    {
        protected ACContext _context;
        protected AppSettings AppSettings { get; set; }
        protected IPathProvider pathProvider;
        protected IMemoryCache cache;
        protected readonly ILogger<ACController> _logger;

        public ACController(ACContext context, IOptions<AppSettings> settings, IPathProvider pathProvider, IMemoryCache cache, ILogger<ACController> logger)
        {
            _context = context;
            AppSettings = settings.Value;
            this.pathProvider = pathProvider;
            this.cache = cache;
            _logger = logger;
        }

        protected CedRentCOMUN.Entidades.Sesion ObtenerSesion()
        {
            var cacheId = "sesion";
            return cache.GetOrCreate<CedRentCOMUN.Entidades.Sesion>(cacheId,
                cacheEntry =>
                {
                    CedRentCOMUN.Entidades.Sesion sesion = new CedRentCOMUN.Entidades.Sesion();
                    Aplicacion aplic = new Aplicacion();
                    aplic.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
                    aplic.VersionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
                    aplic.Ambiente = AppSettings.Ambiente;

                    string path = pathProvider.MapPath("wwwroot\\Logs");

                    CedRentCOMUN.RN.Sesion.Crear(
                        AppSettings.Ambiente,
                        _context.Database.GetDbConnection().ConnectionString,
                        new System.Globalization.CultureInfo("en-GB"),
                        sesion
                        );
                    return sesion;
                });
        }

       
    }
}
