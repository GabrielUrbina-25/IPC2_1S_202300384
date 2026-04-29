namespace ITGSA_Backend.EstructurasPropias;

public class ListaEnlazada<T>
{
    private Nodo<T> _cabeza;
    private int _contador;

    public Nodo<T> Cabeza => _cabeza;
    public int Contar => _contador;

    public void Agregar(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);
        if (_cabeza == null)
        {
            _cabeza = nuevo;
        }
        else
        {
            Nodo<T> actual = _cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
        _contador++;
    }

    public T Buscar(Predicate<T> condicion)
    {
        Nodo<T> actual = _cabeza;
        while (actual != null)
        {
            if (condicion(actual.Dato))
                return actual.Dato;
            actual = actual.Siguiente;
        }
        return default;
    }

    public bool Existe(Predicate<T> condicion) => Buscar(condicion) != null;

    public void Actualizar(Predicate<T> condicion, Action<T> modificador)
    {
        Nodo<T> actual = _cabeza;
        while (actual != null)
        {
            if (condicion(actual.Dato))
            {
                modificador(actual.Dato);
                return;
            }
            actual = actual.Siguiente;
        }
    }

    public void Limpiar()
    {
        _cabeza = null;
        _contador = 0;
    }

    public T[] ToArray()
    {
        T[] array = new T[_contador];
        Nodo<T> actual = _cabeza;
        for (int i = 0; i < _contador; i++)
        {
            array[i] = actual.Dato;
            actual = actual.Siguiente;
        }
        return array;
    }
}