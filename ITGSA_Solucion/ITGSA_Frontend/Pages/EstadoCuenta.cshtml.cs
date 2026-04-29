using ITGSA_Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace ITGSA_Frontend.Pages;

public class EstadoCuentaModel : PageModel
{
    private readonly ApiService _api = new();

    [BindProperty]
    public string NIT { get; set; } = "";

    public List<ClienteCuenta> Clientes { get; set; } = new();

    public async Task OnPostAsync()
    {
        string xml = await _api.ObtenerEstadoCuentaAsync(NIT);
        var doc = XDocument.Parse(xml);

        foreach (var xc in doc.Descendants("cliente"))
        {
            var cliente = new ClienteCuenta
            {
                NIT = xc.Element("NIT")?.Value,
                Nombre = xc.Element("nombre")?.Value,
                SaldoActual = xc.Element("saldoActual")?.Value
            };

            foreach (var xt in xc.Descendants("transaccion"))
            {
                cliente.Transacciones.Add(new TransaccionView
                {
                    Fecha = xt.Element("fecha")?.Value,
                    Cargo = double.TryParse(xt.Element("cargo")?.Value, out double c) ? c : 0,
                    Abono = double.TryParse(xt.Element("abono")?.Value, out double a) ? a : 0,
                    Referencia = xt.Element("referencia")?.Value
                });
            }

            Clientes.Add(cliente);
        }
    }
}

public class ClienteCuenta
{
    public string NIT { get; set; }
    public string Nombre { get; set; }
    public string SaldoActual { get; set; }
    public List<TransaccionView> Transacciones { get; set; } = new();
}

public class TransaccionView
{
    public string Fecha { get; set; }
    public double Cargo { get; set; }
    public double Abono { get; set; }
    public string Referencia { get; set; }
}