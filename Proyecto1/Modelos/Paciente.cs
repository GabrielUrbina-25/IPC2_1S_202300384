namespace Proyecto1.Modelos
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int PeriodosEvaluar { get; set; } // N máximo
        public int TamañoRejilla { get; set; } // M
        public Rejilla RejillaInicial { get; set; }
        public Rejilla RejillaActual { get; set; }

        // Campos para resultado (se llenarán en fases posteriores)
        public string Resultado { get; set; } // "leve", "grave", "mortal"
        public int? N { get; set; } // Período de repetición inicial
        public int? N1 { get; set; } // Período secundario de repetición

        public Paciente(string nombre, int edad, int periodos, int tamaño)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.PeriodosEvaluar = periodos;
            this.TamañoRejilla = tamaño;
            this.RejillaInicial = new Rejilla(tamaño);
            this.RejillaActual = null;
            this.Resultado = "pendiente";
        }

        public override string ToString()
        {
            return $"{Nombre} (Edad: {Edad}) - Rejilla {TamañoRejilla}x{TamañoRejilla}, " +
                   $"Periodos a evaluar: {PeriodosEvaluar}";
        }
    }
}