using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Controladores
{
    public class GestorSistemas
    {
        private static GestorSistemas instancia;
        private ListaSimple sistemas;

        private GestorSistemas()
        {
            sistemas = new ListaSimple();
        }

        public static GestorSistemas Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new GestorSistemas();
                return instancia;
            }
        }

        public void AgregarSistema(SistemaDrones sistema)
        {
            sistemas.Agregar(sistema);
        }

        public ListaSimple ObtenerSistemas()
        {
            return sistemas;
        }

        public SistemaDrones BuscarSistema(string nombre)
        {
            object resultado = sistemas.Buscar(s => ((SistemaDrones)s).Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            return (SistemaDrones)resultado;
        }
    }
}
