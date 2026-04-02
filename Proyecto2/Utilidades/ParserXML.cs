using Proyecto2.Controladores;
using Proyecto2.Estructuras;
using Proyecto2.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Proyecto2.Utilidades
{
    public class ParserXML
    {
        public static void CargarDesdeXML(string rutaArchivo)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaArchivo);

            // 1. Cargar Drones
            XmlNodeList nodosDrones = doc.SelectNodes("//listaDrones/dron");
            ListaSimple nombresDrones = new ListaSimple();

            foreach (XmlNode nodo in nodosDrones)
            {
                string nombre = nodo.InnerText.Trim();
                nombresDrones.Agregar(nombre);
            }
            GestorDrones.Instancia.CargarDrones(nombresDrones);

            // 2. Cargar Sistemas de Drones
            XmlNodeList nodosSistemas = doc.SelectNodes("//listaSistemasDrones/sistemaDrones");
            foreach (XmlNode nodoSistema in nodosSistemas)
            {
                SistemaDrones sistema = new SistemaDrones();
                sistema.Nombre = nodoSistema.Attributes["nombre"].Value;
                sistema.AlturaMaxima = int.Parse(nodoSistema.SelectSingleNode("alturaMaxima").InnerText);
                sistema.CantidadDrones = int.Parse(nodoSistema.SelectSingleNode("cantidadDrones").InnerText);

                XmlNodeList nodosContenido = nodoSistema.SelectNodes("contenido");
                foreach (XmlNode nodoContenido in nodosContenido)
                {
                    string nombreDron = nodoContenido.SelectSingleNode("dron").InnerText.Trim();
                    DronConfiguracion dronConfig = new DronConfiguracion();
                    dronConfig.NombreDron = nombreDron;

                    XmlNodeList nodosAlturas = nodoContenido.SelectNodes("alturas/altura");
                    foreach (XmlNode nodoAltura in nodosAlturas)
                    {
                        int valor = int.Parse(nodoAltura.Attributes["valor"].Value);
                        string letra = nodoAltura.InnerText.Trim();
                        dronConfig.Alturas.Agregar(new Altura(valor, letra));
                    }

                    sistema.DronesConfiguracion.Agregar(dronConfig);
                }

                GestorSistemas.Instancia.AgregarSistema(sistema);
            }

            // 3. Cargar Mensajes
            XmlNodeList nodosMensajes = doc.SelectNodes("//listaMensajes/Mensaje");
            foreach (XmlNode nodoMensaje in nodosMensajes)
            {
                Mensaje mensaje = new Mensaje();
                mensaje.Nombre = nodoMensaje.Attributes["nombre"].Value;
                mensaje.NombreSistemaDrones = nodoMensaje.SelectSingleNode("sistemaDrones").InnerText.Trim();

                XmlNodeList nodosInstrucciones = nodoMensaje.SelectNodes("instrucciones/instruccion");
                foreach (XmlNode nodoInstruccion in nodosInstrucciones)
                {
                    string nombreDron = nodoInstruccion.Attributes["dron"].Value;
                    int altura = int.Parse(nodoInstruccion.InnerText.Trim());
                    mensaje.Instrucciones.Agregar(new Instruccion(nombreDron, altura));
                }

                GestorMensajes.Instancia.AgregarMensaje(mensaje);
            }
        }
    }
}
