namespace Practica2.Models
{
    public class Nodo
    {
        public Paciente Info;
        public Nodo Siguiente;

        public Nodo(Paciente info)
        {
            Info = info;
            Siguiente = null;
        }
    }
}