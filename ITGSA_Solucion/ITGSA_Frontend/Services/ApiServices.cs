namespace ITGSA_Frontend.Services;

public class ApiService
{
    private readonly HttpClient _http = new();
    private const string URL = "http://localhost:5228/api/itgsa";

    public async Task<string> ResetAsync()
    {
        var resp = await _http.PostAsync($"{URL}/limpiarDatos", null);
        return await resp.Content.ReadAsStringAsync();
    }

    public async Task<string> EnviarConfigAsync(string xml)
    {
        var content = new StringContent(xml, System.Text.Encoding.UTF8, "application/xml");
        var resp = await _http.PostAsync($"{URL}/grabarConfiguracion", content);
        return await resp.Content.ReadAsStringAsync();
    }

    public async Task<string> EnviarTransacAsync(string xml)
    {
        var content = new StringContent(xml, System.Text.Encoding.UTF8, "application/xml");
        var resp = await _http.PostAsync($"{URL}/grabarTransaccion", content);
        return await resp.Content.ReadAsStringAsync();
    }
}