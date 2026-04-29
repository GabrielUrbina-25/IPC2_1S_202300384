namespace ITGSA_Backend.EstructurasPropias;

public class Cola<T>
{
    private Nodo<T> _frente;
    private Nodo<T> _final;
    private int _contador;

    public int Contar => _contador;
    public bool EstaVacia => _contador == 0;

    public void Encolar(T dato)
    {
        Nodo<T> nuevo = new Nodo<T>(dato);
        if (_frente == null)
        {
            _frente = _final = nuevo;
        }
        else
        {
            _final.Siguiente = nuevo;
            _final = nuevo;
        }
        _contador++;
    }

    public T Desencolar()
    {
        if (_frente == null) throw new InvalidOperationException("Cola vacía");
        T dato = _frente.Dato;
        _frente = _frente.Siguiente;
        if (_frente == null) _final = null;
        _contador--;
        return dato;
    }

    public T VerFrente()
    {
        if (_frente == null) throw new InvalidOperationException("Cola vacía");
        return _frente.Dato;
    }

    public void Limpiar()
    {
        _frente = _final = null;
        _contador = 0;
    }
}