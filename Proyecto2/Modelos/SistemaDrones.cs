using System;
using System.Collections.Generic;
using System.Text;
using Proyecto2.Estructuras;

namespace Proyecto2.Modelos
{
    public class SistemaDrones
    {
        public string Nombre { get; set; }
        public int AlturaMaxima { get; set; }
        public int CantidadDrones { get; set; }

        // Lista de DronConfiguracion
        public ListaSimple DronesConfiguracion { get; set; }

        public SistemaDrones()
        {
            DronesConfiguracion = new ListaSimple();
        }
    }

    public class DronConfiguracion
    {
        public string NombreDron { get; set; }
        public ListaSimple Alturas { get; set; }

        public DronConfiguracion()
        {
            Alturas = new ListaSimple();
        }
    }
}
