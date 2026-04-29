using ITGSA_Frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGSA_Frontend.Pages;

public class TransaccionesModel : PageModel
{
    private readonly ApiService _api = new();

    [BindProperty]
    public IFormFile Archivo { get; set; }

    public string Respuesta { get; set; } = "";

    public async Task OnPostAsync()
    {
        if (Archivo != null)
        {
            using var r = new StreamReader(Archivo.OpenReadStream());
            var xml = await r.ReadToEndAsync();
            Respuesta = await _api.EnviarTransacAsync(xml);
        }
    }
}