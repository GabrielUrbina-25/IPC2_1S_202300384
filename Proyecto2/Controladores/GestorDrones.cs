using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2.Controladores
{
    public class GestorDrones
    {
        private static GestorDrones instancia;
        private ListaSimple drones;

        private GestorDrones()
        {
            drones = new ListaSimple();
        }

        public static GestorDrones Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new GestorDrones();
                return instancia;
            }
        }

        public bool AgregarDron(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            // Verificar si ya existe usando Predicate
            if (drones.Existe(d => ((Dron)d).Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                return false;

            drones.AgregarOrdenado(new Dron(nombre));
            return true;
        }

        public ListaSimple ObtenerDrones()
        {
            return drones;
        }

        public bool ExisteDron(string nombre)
        {
            return drones.Existe(d => ((Dron)d).Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public void CargarDrones(ListaSimple nombres)
        {
            nombres.Recorrer(obj =>
            {
                string nombre = (string)obj;
                if (!ExisteDron(nombre))
                {
                    drones.AgregarOrdenado(new Dron(nombre));
                }
            });
        }
    }
}
