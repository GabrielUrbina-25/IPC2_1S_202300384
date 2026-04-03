using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Controladores
{
    public static class OptimizadorTiempo
    {
        // Estructura para rastrear el estado de cada dron
        private class EstadoDron
        {
            public string Nombre { get; set; }
            public int AlturaActual { get; set; }
            public int TiempoDisponible { get; set; } // Cuándo termina su última acción

            public EstadoDron(string nombre)
            {
                Nombre = nombre;
                AlturaActual = 1; // Todos empiezan en altura 1 (suelo)
                TiempoDisponible = 0;
            }
        }

        // Calcula el tiempo óptimo y devuelve la secuencia detallada de acciones
        public static ResultadoOptimizacion CalcularTiempoOptimo(Mensaje mensaje, SistemaDrones sistema)
        {
            ResultadoOptimizacion resultado = new ResultadoOptimizacion();
            resultado.TiempoTotal = 0;
            resultado.Acciones = new ListaSimple(); // Lista de AccionTiempo

            // Diccionario de estados de drones (usando ListaSimple como mapa)
            ListaSimple estadosDrones = new ListaSimple();

            // Inicializar estados para todos los drones del sistema
            for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                estadosDrones.Agregar(new EstadoDron(dc.NombreDron));
            }

            int tiempoGlobal = 0;

            // Procesar cada instrucción en orden
            for (int i = 0; i < mensaje.Instrucciones.Count; i++)
            {
                Instruccion instruccion = (Instruccion)mensaje.Instrucciones.Obtener(i);

                // Buscar estado del dron
                EstadoDron estado = BuscarEstado(estadosDrones, instruccion.NombreDron);

                if (estado == null) continue; // Dron no existe en el sistema

                AccionTiempo accion = new AccionTiempo();
                accion.Dron = instruccion.NombreDron;
                accion.AlturaObjetivo = instruccion.Altura;
                accion.Inicio = Math.Max(tiempoGlobal, estado.TiempoDisponible);

                // Calcular tiempo de movimiento (subir/bajar)
                int diferenciaAltura = Math.Abs(instruccion.Altura - estado.AlturaActual);
                int tiempoMovimiento = diferenciaAltura * 1; // 1 segundo por metro

                // Encender luz (1 segundo)
                int tiempoEncendido = 1;

                accion.Fin = accion.Inicio + tiempoMovimiento + tiempoEncendido;
                accion.DuracionTotal = tiempoMovimiento + tiempoEncendido;
                accion.AlturaInicial = estado.AlturaActual;
                accion.TiempoMovimiento = tiempoMovimiento;

                // Actualizar estado del dron
                estado.AlturaActual = instruccion.Altura;
                estado.TiempoDisponible = accion.Fin;

                // Actualizar tiempo global (solo un dron a la vez puede emitir)
                tiempoGlobal = accion.Fin;

                resultado.Acciones.Agregar(accion);
            }

            // El tiempo total es el fin de la última acción
            if (resultado.Acciones.Count > 0)
            {
                AccionTiempo ultima = (AccionTiempo)resultado.Acciones.Obtener(resultado.Acciones.Count - 1);
                resultado.TiempoTotal = ultima.Fin;
            }

            return resultado;
        }

        private static EstadoDron BuscarEstado(ListaSimple estados, string nombreDron)
        {
            for (int i = 0; i < estados.Count; i++)
            {
                EstadoDron ed = (EstadoDron)estados.Obtener(i);
                if (ed.Nombre.Equals(nombreDron, StringComparison.OrdinalIgnoreCase))
                    return ed;
            }
            return null;
        }

        // Decodificar mensaje (convertir instrucciones a texto)
        public static string DecodificarMensaje(Mensaje mensaje, SistemaDrones sistema)
        {
            StringBuilder mensajeDecodificado = new StringBuilder();

            for (int i = 0; i < mensaje.Instrucciones.Count; i++)
            {
                Instruccion inst = (Instruccion)mensaje.Instrucciones.Obtener(i);
                string letra = BuscarLetraEnSistema(sistema, inst.NombreDron, inst.Altura);
                mensajeDecodificado.Append(letra);
            }

            return mensajeDecodificado.ToString();
        }

        private static string BuscarLetraEnSistema(SistemaDrones sistema, string nombreDron, int altura)
        {
            for (int i = 0; i < sistema.DronesConfiguracion.Count; i++)
            {
                DronConfiguracion dc = (DronConfiguracion)sistema.DronesConfiguracion.Obtener(i);
                if (dc.NombreDron.Equals(nombreDron, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = 0; j < dc.Alturas.Count; j++)
                    {
                        Altura a = (Altura)dc.Alturas.Obtener(j);
                        if (a.Valor == altura)
                            return string.IsNullOrWhiteSpace(a.Letra) ? " " : a.Letra;
                    }
                }
            }
            return "?"; // No encontrado
        }
    }

    public class ResultadoOptimizacion
    {
        public int TiempoTotal { get; set; }
        public ListaSimple Acciones { get; set; } // Lista de AccionTiempo
    }

    public class AccionTiempo
    {
        public string Dron { get; set; }
        public int AlturaInicial { get; set; }
        public int AlturaObjetivo { get; set; }
        public int Inicio { get; set; }
        public int Fin { get; set; }
        public int DuracionTotal { get; set; }
        public int TiempoMovimiento { get; set; }

        public override string ToString()
        {
            string movimiento = AlturaInicial < AlturaObjetivo ? "Subir" : "Bajar";
            return $"T{Inicio}-{Fin}: {Dron} {movimiento} de {AlturaInicial} a {AlturaObjetivo}m, emitir luz";
        }
    }
}
