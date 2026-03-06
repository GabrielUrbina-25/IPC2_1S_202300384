using Proyecto1.EstructurasDatos;
using Proyecto1.Modelos;
using Proyecto1.Modelos;
using System;

namespace Proyecto1.Servicios
{
    public class SimuladorEpidemico
    {
        // Reglas del autómata celular (Game of Life modificado)
        public Rejilla CalcularSiguientePeriodo(Rejilla actual)
        {
            int tamaño = actual.Tamaño;
            Rejilla siguiente = new Rejilla(tamaño);
            siguiente.PeriodoActual = actual.PeriodoActual + 1;

            for (int fila = 0; fila < tamaño; fila++)
            {
                for (int col = 0; col < tamaño; col++)
                {
                    Celda celdaActual = actual.ObtenerCelda(fila, col);
                    int vecinosContagiados = ContarVecinosContagiados(actual, fila, col);

                    bool nuevoEstado = DeterminarNuevoEstado(celdaActual.EstaContagiada, vecinosContagiados);
                    siguiente.EstablecerCelda(fila, col, nuevoEstado);
                }
            }

            return siguiente;
        }

        private int ContarVecinosContagiados(Rejilla rejilla, int fila, int col)
        {
            int contador = 0;

            // Revisar las 8 celdas vecinas
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue; // Saltar la celda actual

                    int nuevaFila = fila + i;
                    int nuevaCol = col + j;

                    // Verificar límites
                    if (nuevaFila >= 0 && nuevaFila < rejilla.Tamaño &&
                        nuevaCol >= 0 && nuevaCol < rejilla.Tamaño)
                    {
                        if (rejilla.ObtenerCelda(nuevaFila, nuevaCol).EstaContagiada)
                        {
                            contador++;
                        }
                    }
                }
            }

            return contador;
        }

        private bool DeterminarNuevoEstado(bool estaContagiada, int vecinosContagiados)
        {
            if (estaContagiada)
            {
                // Regla 1: Celda contagiada permanece contagiada si tiene 2 o 3 vecinos contagiados
                return vecinosContagiados == 2 || vecinosContagiados == 3;
            }
            else
            {
                // Regla 2: Celda sana se contagia si tiene exactamente 3 vecinos contagiados
                return vecinosContagiados == 3;
            }
        }

        // Avanzar un período específico
        public Rejilla AvanzarPeriodo(Paciente paciente)
        {
            if (paciente.RejillaActual == null)
            {
                paciente.RejillaActual = CopiarRejilla(paciente.RejillaInicial);
                return paciente.RejillaActual;
            }

            paciente.RejillaActual = CalcularSiguientePeriodo(paciente.RejillaActual);
            return paciente.RejillaActual;
        }

        // Copiar rejilla (para no modificar la original)
        private Rejilla CopiarRejilla(Rejilla original)
        {
            Rejilla copia = new Rejilla(original.Tamaño);
            copia.PeriodoActual = original.PeriodoActual;

            for (int i = 0; i < original.Tamaño; i++)
            {
                for (int j = 0; j < original.Tamaño; j++)
                {
                    bool estado = original.ObtenerCelda(i, j).EstaContagiada;
                    copia.EstablecerCelda(i, j, estado);
                }
            }

            return copia;
        }
    }
}