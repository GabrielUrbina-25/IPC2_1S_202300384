using ITGSA_Frontend.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITGSA_Frontend.Pages;

public class IndexModel : PageModel
{
    private readonly ApiService _api = new();
    public string Mensaje { get; set; } = "";

    public async Task OnPostResetAsync()
    {
        Mensaje = await _api.ResetAsync();
    }
}