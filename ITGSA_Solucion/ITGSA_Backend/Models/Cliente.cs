namespace ITGSA_Backend.Models;

public class Cliente
{
    public string NIT { get; set; }
    public string Nombre { get; set; }
    public double SaldoFavor { get; set; }

    public Cliente() { SaldoFavor = 0; }
}