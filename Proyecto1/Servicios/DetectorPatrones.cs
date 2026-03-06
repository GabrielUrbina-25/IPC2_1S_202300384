using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using System;

namespace Proyecto1.Servicios
{
    public class DetectorPatrones
    {
        private ListaEnlazada<HistorialPatron> historial;
        private string patronInicial;

        public DetectorPatrones()
        {
            this.historial = new ListaEnlazada<HistorialPatron>();
        }

        // Inicializar con la rejilla inicial del paciente
        public void Inicializar(Rejilla rejillaInicial)
        {
            historial.Limpiar();
            patronInicial = rejillaInicial.ObtenerPatron();
            historial.Agregar(new HistorialPatron(patronInicial, 0, rejillaInicial));
        }

        // Analizar un nuevo período y determinar si hay repetición
        // Retorna: null si no hay repetición, o tupla (tipo, N, N1)
        public ResultadoAnalisis AnalizarPeriodo(Rejilla rejillaActual, int periodoActual)
        {
            string patronActual = rejillaActual.ObtenerPatron();

            // Buscar si este patrón ya existe en el historial
            for (int i = 0; i < historial.Count; i++)
            {
                var registro = historial.Obtener(i);

                if (registro.Patron == patronActual)
                {
                    // ¡Patrón repetido encontrado!
                    return ClasificarResultado(registro.Periodo, periodoActual);
                }
            }

            // No es repetición, agregar al historial
            historial.Agregar(new HistorialPatron(patronActual, periodoActual, rejillaActual));
            return null;
        }

        private ResultadoAnalisis ClasificarResultado(int periodoPrimeraAparicion, int periodoActual)
        {
            var resultado = new ResultadoAnalisis();

            if (periodoPrimeraAparicion == 0)
            {
                // El patrón inicial se repite
                resultado.N = periodoActual;

                if (periodoActual == 1)
                {
                    resultado.Tipo = "mortal";
                    resultado.Mensaje = $"ENFERMEDAD MORTAL: El patrón inicial se repite cada período (N=1)";
                }
                else
                {
                    resultado.Tipo = "grave";
                    resultado.Mensaje = $"ENFERMEDAD GRAVE: El patrón inicial se repite cada {periodoActual} períodos (N={periodoActual})";
                }
            }
            else
            {
                // Un patrón posterior se repite
                resultado.N = periodoPrimeraAparicion;
                resultado.N1 = periodoActual - periodoPrimeraAparicion;

                if (resultado.N1 == 1)
                {
                    resultado.Tipo = "mortal";
                    resultado.Mensaje = $"ENFERMEDAD MORTAL: Patrón del período {periodoPrimeraAparicion} se repite cada período (N={periodoPrimeraAparicion}, N1=1)";
                }
                else
                {
                    resultado.Tipo = "grave";
                    resultado.Mensaje = $"ENFERMEDAD GRAVE: Patrón del período {periodoPrimeraAparicion} se repite cada {resultado.N1} períodos (N={periodoPrimeraAparicion}, N1={resultado.N1})";
                }
            }

            return resultado;
        }

        // Verificar si se alcanzó el límite sin repetición
        public ResultadoAnalisis ClasificarSinRepeticion(int periodosEvaluados)
        {
            return new ResultadoAnalisis
            {
                Tipo = "leve",
                N = null,
                N1 = null,
                Mensaje = $"ENFERMEDAD LEVE: No se detectaron patrones repetitivos en {periodosEvaluados} períodos evaluados"
            };
        }

        public ListaEnlazada<HistorialPatron> ObtenerHistorial()
        {
            return historial;
        }
    }

    public class ResultadoAnalisis
    {
        public string Tipo { get; set; }      // "leve", "grave", "mortal"
        public int? N { get; set; }           // Período de primera aparición/repetición
        public int? N1 { get; set; }          // Período secundario (solo para patrones no iniciales)
        public string Mensaje { get; set; }
    }
}