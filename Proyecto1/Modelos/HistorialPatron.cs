using Proyecto1.Modelos;

namespace Proyecto1.Modelos
{
    public class HistorialPatron
    {
        public string Patron { get; set; }
        public int Periodo { get; set; }
        public Rejilla Rejilla { get; set; }

        public HistorialPatron(string patron, int periodo, Rejilla rejilla)
        {
            this.Patron = patron;
            this.Periodo = periodo;
            this.Rejilla = rejilla;
        }
    }
}