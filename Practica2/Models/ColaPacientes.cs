namespace Practica2.Models
{
    public class ColaPacientes
    {
        private Nodo primero;
        private Nodo ultimo;

        public bool EstaVacia()
        {
            return primero == null;
        }

        public void Encolar(Paciente p)
        {
            Nodo nuevo = new Nodo(p);

            if (EstaVacia())
            {
                primero = ultimo = nuevo;
            }
            else
            {
                ultimo.Siguiente = nuevo;
                ultimo = nuevo;
            }

            ActualizarTiempos();
        }

        public Paciente Desencolar()
        {
            if (EstaVacia()) return null;

            Paciente p = primero.Info;
            primero = primero.Siguiente;

            if (primero == null)
                ultimo = null;

            ActualizarTiempos();
            return p;
        }

        public int Tamano()
        {
            int count = 0;
            Nodo aux = primero;

            while (aux != null)
            {
                count++;
                aux = aux.Siguiente;
            }

            return count;
        }

        private void ActualizarTiempos()
        {
            Nodo actual = primero;
            int tiempo = 0;

            while (actual != null)
            {
                actual.Info.TiempoEsperaEstimado = tiempo;
                tiempo += actual.Info.TiempoAtencion;
                actual = actual.Siguiente;
            }
        }

        public string Mostrar()
        {
            if (EstaVacia()) return "COLA VACÍA";

            string texto = "";
            Nodo aux = primero;

            while (aux != null)
            {
                texto += aux.Info.ToString() + " -> ";
                aux = aux.Siguiente;
            }

            return texto;
        }
        public System.Collections.Generic.List<Paciente> ALista()
        {
            var lista = new System.Collections.Generic.List<Paciente>();
            Nodo actual = primero;

            while (actual != null)
            {
                lista.Add(actual.Info);
                actual = actual.Siguiente;
            }

            return lista;
        }

        public int ObtenerTiempoTotal()
        {
            Nodo actual = primero;
            int total = 0;

            while (actual != null)
            {
                total += actual.Info.TiempoAtencion;
                actual = actual.Siguiente;
            }

            return total;
        }
    }
}