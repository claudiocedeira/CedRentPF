using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CedRentFIMAAPIPOM.Controllers
{
    [ApiController]
    public class RentaController : ACController
    {
        public RentaController(Models.ACContext context, IOptions<AppSettings> settings, IPathProvider pathProvider, IMemoryCache cache, ILogger<ACController> logger) : base(context, settings, pathProvider, cache, logger)
        {
        }
        [Route("/v1/pom/investments/profitability-fima/last-day")]
        [HttpPost]
        public ActionResult<CedRentCOMUN.Entidades.RentaUltimoDia> ObtenerRentaUltimoDia(CedRentCOMUN.Entidades.RentaUltimoDiaFiltro rentaUltimoDiaFiltro)
        {
            _logger.LogInformation(string.Format("ObtenerRentaUltimoDia: RentaUltimoDiaFiltro={0}", JsonConvert.SerializeObject(rentaUltimoDiaFiltro)));
            try
            {
                CedRentCOMUN.Entidades.RentaUltimoDia renta = CedRentFIMA.RN.RentaUltimoDia.Obtener(rentaUltimoDiaFiltro, ObtenerSesion());
                _logger.LogInformation($"El metodo ObtenerRentaUltimoDia(): {JsonConvert.SerializeObject(renta)}");
                return renta;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en metodo ObtenerRentaUltimoDia(): {ex.ToString()}");
                throw;
            }
        }

        [Route("/v1/pom/investments/profitability-fima")]
        [HttpPost]
        public ActionResult<List<CedRentCOMUN.Entidades.RentaOrden>> ObtenerRentaPorRealizacion([FromBody] List<string> paramsLists)
        {
            _logger.LogInformation(string.Format("ObtenerRentaPorRealizacion: paramsLists={0}", JsonConvert.SerializeObject(paramsLists)));
            try
            {
                List<CedRentCOMUN.Entidades.RentaOrden> renta = CedRentFIMA.RN.RentaPorRealizacion.Obtener(paramsLists, ObtenerSesion());
                _logger.LogInformation($"El metodo ObtenerRentaPorRealizacion(): {JsonConvert.SerializeObject(renta)}");
                return renta;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en metodo ObtenerRentaPorRealizacion(): {ex.ToString()}");
                throw;
            }
        }

        [Route("/v1/pom/investments/profitability-fima/week")]
        [HttpGet]
        public ActionResult<CedRentCOMUN.Entidades.RentaPeriodo> ObtenerRenta7dias(DateTime FechaRef, string CtaInv, string SubCtaInv, string ProductoId)
        {
            _logger.LogInformation(string.Format("ObtenerRenta7dias: FechaRef={0}, CtaInv={1}, SubCtaInv={2}, ProductoId={3}", FechaRef, CtaInv, SubCtaInv, ProductoId));
            try
            {
                CedRentCOMUN.Entidades.RentaPeriodo renta= CedRentFIMA.RN.Renta7d.Obtener(FechaRef, CtaInv, SubCtaInv, ProductoId, ObtenerSesion());
                _logger.LogInformation($"El metodo ObtenerRenta7dias(): {JsonConvert.SerializeObject(renta)}");
                System.Console.WriteLine(JsonConvert.SerializeObject(renta));
                return renta;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en metodo ObtenerRenta7dias(): {ex.ToString()}");
                throw;
            }
        }

        [Route("/v1/pom/investments/profitability-fima/month")]
        [HttpGet]
        public ActionResult<CedRentCOMUN.Entidades.RentaPeriodo> ObtenerRenta30dias(DateTime FechaRef, string CtaInv, string SubCtaInv, string ProductoId)
        {
            _logger.LogInformation(string.Format("ObtenerRenta30dias: FechaRef={0}, CtaInv={1}, SubCtaInv={2}, ProductoId={3}", FechaRef, CtaInv, SubCtaInv, ProductoId));
            try
            {
                CedRentCOMUN.Entidades.RentaPeriodo renta = CedRentFIMA.RN.Renta30d.Obtener(FechaRef, CtaInv, SubCtaInv, ProductoId, ObtenerSesion());
                _logger.LogInformation($"El metodo ObtenerRenta30dias(): {JsonConvert.SerializeObject(renta)}");
                return renta;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en metodo ObtenerRenta30dias(): {ex.ToString()}");
                throw;
            }
        }

        [Route("/v1/pom/investments/profitability-fima/year")]
        [HttpGet]
        public ActionResult<CedRentCOMUN.Entidades.RentaPeriodo> ObtenerRenta12meses(DateTime FechaRef, string CtaInv, string SubCtaInv, string ProductoId)
        {
            _logger.LogInformation(string.Format("ObtenerRenta12meses: FechaRef={0}, CtaInv={1}, SubCtaInv={2}, ProductoId={3}", FechaRef, CtaInv, SubCtaInv, ProductoId));
            try
            {
                CedRentCOMUN.Entidades.RentaPeriodo renta = CedRentFIMA.RN.Renta12m.Obtener(FechaRef, CtaInv, SubCtaInv, ProductoId, ObtenerSesion());
                _logger.LogInformation($"El metodo ObtenerRenta12meses(): {JsonConvert.SerializeObject(renta)}");
                return renta;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en metodo ObtenerRenta12meses(): {ex.ToString()}");
                throw;
            }
        }

        [Route("/v1/pom/investments/profitability-fima/day")]
        [HttpGet]
        public ActionResult<CedRentCOMUN.Entidades.RentaPeriodo> ObtenerRentaXdia(DateTime FechaDsd, DateTime FechaHst, string CtaInv, string SubCtaInv, string ProductoId)
        {
            _logger.LogInformation(string.Format("ObtenerRentaXdia: FechaDsd={0}, FechaHst={4}, CtaInv={1}, SubCtaInv={2}, ProductoId={3}", FechaDsd, CtaInv, SubCtaInv, ProductoId, FechaHst));
            try
            {
                CedRentCOMUN.Entidades.RentaPeriodo renta = CedRentFIMA.RN.Rentaxd.Obtener(FechaDsd, FechaHst, CtaInv, SubCtaInv, ProductoId, ObtenerSesion());
                _logger.LogInformation($"El metodo ObtenerRentaXdia(): {JsonConvert.SerializeObject(renta)}");
                return renta;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error en metodo ObtenerRentaXdia(): {ex.ToString()}");
                throw;
            }
        }
    }
}
