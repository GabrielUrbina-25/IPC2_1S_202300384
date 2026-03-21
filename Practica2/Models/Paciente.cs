using System;
using System.Collections.Generic;

namespace Practica2.Models
{
    public class Paciente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Especialidad { get; set; }

        public int TiempoAtencion { get; set; }
        public int TiempoEsperaEstimado { get; set; }

        private static Dictionary<string, int> TIEMPOS = new Dictionary<string, int>()
        {
            { "Medicina General", 10 },
            { "Pediatría", 15 },
            { "Ginecología", 20 },
            { "Dermatología", 25 }
        };

        public Paciente(string nombre, int edad, string especialidad)
        {
            Nombre = nombre;
            Edad = edad;
            Especialidad = especialidad;
            TiempoAtencion = TIEMPOS.ContainsKey(especialidad) ? TIEMPOS[especialidad] : 10;
            TiempoEsperaEstimado = 0;
        }

        public int ObtenerTiempoTotal()
        {
            return TiempoAtencion + TiempoEsperaEstimado;
        }

        public bool EsIgual(string nombre)
        {
            return Nombre.ToLower().Equals(nombre.ToLower());
        }

        public override string ToString()
        {
            return $"{Nombre} - {Especialidad} ({TiempoAtencion} min)";
        }
    }
}