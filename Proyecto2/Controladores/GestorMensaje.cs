using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Controladores
{
    public class GestorMensajes
    {
        private static GestorMensajes instancia;
        private ListaSimple mensajes;

        private GestorMensajes()
        {
            mensajes = new ListaSimple();
        }

        public static GestorMensajes Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new GestorMensajes();
                return instancia;
            }
        }

        public void AgregarMensaje(Mensaje mensaje)
        {
            mensajes.AgregarOrdenadoMensaje(mensaje);
        }

        public ListaSimple ObtenerMensajes()
        {
            return mensajes;
        }

        public Mensaje BuscarMensaje(string nombre)
        {
            object resultado = mensajes.Buscar(m => ((Mensaje)m).Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return (Mensaje)resultado;
        }
    }
}
