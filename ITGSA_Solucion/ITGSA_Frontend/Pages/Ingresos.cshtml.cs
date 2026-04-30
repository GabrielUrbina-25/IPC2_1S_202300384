using ITGSA_Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Xml.Linq;

namespace ITGSA_Frontend.Pages;

public class IngresosModel : PageModel
{
    private readonly ApiService _api = new();

    [BindProperty]
    public int Mes { get; set; }

    [BindProperty]
    public int Anio { get; set; }

    public string NombreMes { get; set; } = "";
    public List<MesIngreso> Meses { get; set; } = new();
    public List<string> BancosLabels { get; set; } = new();

    public async Task OnPostAsync()
    {
        await CargarDatos(Mes, Anio);
    }

    public async Task<IActionResult> OnPostPdfAsync()
    {
        await CargarDatos(Mes, Anio);

        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4.Landscape());
                page.Margin(2, Unit.Centimetre);

                page.Header().Text($"Ingresos por Banco - {NombreMes}/{Anio}").Bold().FontSize(20);

                page.Content().Column(col =>
                {
                    foreach (var mes in Meses)
                    {
                        col.Item().PaddingTop(15).Text($"{mes.NombreMes}/{mes.Anio}").Bold().FontSize(14);

                        col.Item().PaddingTop(10).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn();
                                c.ConstantColumn(150);
                            });

                            table.Header(h =>
                            {
                                h.Cell().Text("Banco").Bold();
                                h.Cell().Text("Total (Q)").Bold();
                            });

                            foreach (var b in mes.Bancos)
                            {
                                table.Cell().Text(b.Nombre);
                                table.Cell().Text(b.Total.ToString("F2"));
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

        return File(stream, "application/pdf", $"Ingresos_{NombreMes}_{Anio}.pdf");
    }

    private async Task CargarDatos(int mes, int anio)
    {
        var nombresMeses = new[] { "", "enero", "febrero", "marzo", "abril", "mayo", "junio",
            "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };

        NombreMes = nombresMeses[mes];

        // Cargar 3 meses descendentes
        for (int i = 0; i < 3; i++)
        {
            int m = mes - i;
            int a = anio;
            if (m <= 0) { m += 12; a--; }

            string xml = await _api.ObtenerResumenPagosAsync(m, a);
            var doc = XDocument.Parse(xml);

            var mesIngreso = new MesIngreso
            {
                Mes = m,
                Anio = a,
                NombreMes = nombresMeses[m]
            };

            foreach (var xb in doc.Descendants("banco"))
            {
                mesIngreso.Bancos.Add(new BancoIngreso
                {
                    Codigo = int.TryParse(xb.Element("codigo")?.Value, out int c) ? c : 0,
                    Nombre = xb.Element("nombre")?.Value ?? "Desconocido",
                    Total = double.TryParse(xb.Element("total")?.Value, out double t) ? t : 0
                });
            }

            Meses.Add(mesIngreso);
        }

        // Extraer labels de bancos del primer mes
        if (Meses.Count > 0 && Meses[0].Bancos.Count > 0)
        {
            BancosLabels = Meses[0].Bancos.Select(b => b.Nombre).ToList();
        }
    }
}

public class MesIngreso
{
    public int Mes { get; set; }
    public int Anio { get; set; }
    public string NombreMes { get; set; }
    public List<BancoIngreso> Bancos { get; set; } = new();
}

public class BancoIngreso
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public double Total { get; set; }
}