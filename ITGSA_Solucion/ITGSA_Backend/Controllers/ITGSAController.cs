using ITGSA_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ITGSA_Backend.Controllers;

[ApiController]
[Route("api/itgsa")]
public class ITGSAController : ControllerBase
{
    private readonly DataService _ds = DataService.Instancia;

    [HttpPost("limpiarDatos")]
    public IActionResult LimpiarDatos()
    {
        _ds.LimpiarDatos();
        var r = new XDocument(new XElement("respuesta", "Sistema reseteado"));
        return Content(r.ToString(), "application/xml");
    }

    [HttpPost("grabarConfiguracion")]
    public async Task<IActionResult> GrabarConfiguracion()
    {
        try
        {
            using var reader = new StreamReader(Request.Body);
            string xmlContent = await reader.ReadToEndAsync();

            var (cc, ca, bc, ba) = _ds.ProcesarConfiguracion(xmlContent);
            var r = new XDocument(
                new XElement("respuesta",
                    new XElement("clientes",
                        new XElement("creados", cc),
                        new XElement("actualizados", ca)),
                    new XElement("bancos",
                        new XElement("creados", bc),
                        new XElement("actualizados", ba))));
            return Content(r.ToString(), "application/xml");
        }
        catch (Exception ex)
        {
            return BadRequest(new XDocument(new XElement("error", ex.Message)).ToString());
        }
    }

    [HttpPost("grabarTransaccion")]
    public async Task<IActionResult> GrabarTransaccion()
    {
        try
        {
            using var reader = new StreamReader(Request.Body);
            string xmlContent = await reader.ReadToEndAsync();

            var (nf, df, ef, np, dp, ep) = _ds.ProcesarTransacciones(xmlContent);
            var r = new XDocument(
                new XElement("transacciones",
                    new XElement("facturas",
                        new XElement("nuevasFacturas", nf),
                        new XElement("facturasDuplicadas", df),
                        new XElement("facturasConError", ef)),
                    new XElement("pagos",
                        new XElement("nuevosPagos", np),
                        new XElement("pagosDuplicados", dp),
                        new XElement("pagosConError", ep))));
            return Content(r.ToString(), "application/xml");
        }
        catch (Exception ex)
        {
            return BadRequest(new XDocument(new XElement("error", ex.Message)).ToString());
        }
    }

    [HttpGet("devolverEstadoCuenta")]
    public IActionResult DevolverEstadoCuenta([FromQuery] string nit)
    {
        var doc = _ds.ObtenerEstadoCuenta(nit ?? "");
        return Content(doc.ToString(), "application/xml");
    }

    [HttpGet("devolverResumenPagos")]
    public IActionResult DevolverResumenPagos([FromQuery] int mes, [FromQuery] int anio)
    {
        var doc = _ds.ObtenerResumenPagos(mes, anio);
        return Content(doc.ToString(), "application/xml");
    }
}