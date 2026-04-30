using ITGSA_Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
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
        await CargarDatos(NIT);
    }

    public async Task<IActionResult> OnPostPdfAsync()
    {
        await CargarDatos(NIT);

        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);

                page.Header().Text("Estado de Cuenta - ITGSA").Bold().FontSize(20);

                page.Content().Column(col =>
                {
                    foreach (var c in Clientes)
                    {
                        col.Item().PaddingTop(15).Text($"Cliente: {c.NIT} – {c.Nombre}").Bold().FontSize(14);
                        col.Item().Text($"Saldo actual: Q.{c.SaldoActual}").FontSize(12);

                        col.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(def =>
                            {
                                def.RelativeColumn();
                                def.ConstantColumn(100);
                                def.ConstantColumn(100);
                                def.RelativeColumn();
                            });

                            table.Header(h =>
                            {
                                h.Cell().Text("Fecha").Bold();
                                h.Cell().Text("Cargo").Bold();
                                h.Cell().Text("Abono").Bold();
                                h.Cell().Text("Referencia").Bold();
                            });

                            foreach (var t in c.Transacciones)
                            {
                                table.Cell().Text(t.Fecha);
                                table.Cell().Text(t.Cargo > 0 ? $"Q.{t.Cargo:F2}" : "-");
                                table.Cell().Text(t.Abono > 0 ? $"Q.{t.Abono:F2}" : "-");
                                table.Cell().Text(t.Referencia);
                            }
                        });

                        col.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    }
                });

                page.Footer().AlignCenter().Text(txt =>
                {
                    txt.Span("Página ");
                    txt.CurrentPageNumber();
                });
            });
        });

        var stream = new MemoryStream();
        pdf.GeneratePdf(stream);
        stream.Position = 0;

        return File(stream, "application/pdf", $"EstadoCuenta_{DateTime.Now:yyyyMMdd}.pdf");
    }

    private async Task CargarDatos(string nit)
    {
        string xml = await _api.ObtenerEstadoCuentaAsync(nit);
        var doc = XDocument.Parse(xml);

        foreach (var xc in doc.Descendants("cliente"))
        {
            var cliente = new ClienteCuenta
            {
                NIT = xc.Element("NIT")?.Value,
                Nombre = xc.Element("nombre")?.Value,
                SaldoActual = Math.Abs(double.TryParse(xc.Element("saldoActual")?.Value, out double s) ? s : 0).ToString("F2")
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