using ITGSA_Backend.EstructurasPropias;
using ITGSA_Backend.Models;
using System.Xml.Linq;

namespace ITGSA_Backend.Services;

public class DataService
{
    private static DataService _instancia;
    private static readonly object _lock = new object();

    public ListaEnlazada<Cliente> Clientes { get; private set; }
    public ListaEnlazada<Banco> Bancos { get; private set; }
    public ListaEnlazada<Factura> Facturas { get; private set; }
    public ListaEnlazada<Pago> Pagos { get; private set; }

    private readonly string _rutaData = "Data";
    private readonly string _rutaClientes;
    private readonly string _rutaBancos;
    private readonly string _rutaFacturas;
    private readonly string _rutaPagos;

    private DataService()
    {
        Clientes = new ListaEnlazada<Cliente>();
        Bancos = new ListaEnlazada<Banco>();
        Facturas = new ListaEnlazada<Factura>();
        Pagos = new ListaEnlazada<Pago>();

        Directory.CreateDirectory(_rutaData);
        _rutaClientes = Path.Combine(_rutaData, "clientes.xml");
        _rutaBancos = Path.Combine(_rutaData, "bancos.xml");
        _rutaFacturas = Path.Combine(_rutaData, "facturas.xml");
        _rutaPagos = Path.Combine(_rutaData, "pagos.xml");

        CargarDatos();
    }

    public static DataService Instancia
    {
        get
        {
            if (_instancia == null)
            {
                lock (_lock)
                {
                    _instancia ??= new DataService();
                }
            }
            return _instancia;
        }
    }

    public void LimpiarDatos()
    {
        Clientes.Limpiar();
        Bancos.Limpiar();
        Facturas.Limpiar();
        Pagos.Limpiar();
        GuardarDatos();
    }

    public (int cliCreados, int cliActualizados, int banCreados, int banActualizados)
        ProcesarConfiguracion(string xmlContent)
    {
        int cliCreados = 0, cliAct = 0, banCreados = 0, banAct = 0;
        XDocument doc = XDocument.Parse(xmlContent);

        foreach (var cx in doc.Descendants("cliente"))
        {
            string nit = cx.Element("NIT")?.Value?.Trim();
            string nom = cx.Element("nombre")?.Value?.Trim();
            if (string.IsNullOrEmpty(nit) || string.IsNullOrEmpty(nom)) continue;

            var existente = Clientes.Buscar(c => c.NIT == nit);
            if (existente != null)
            {
                Clientes.Actualizar(c => c.NIT == nit, c => c.Nombre = nom);
                cliAct++;
            }
            else
            {
                Clientes.Agregar(new Cliente { NIT = nit, Nombre = nom });
                cliCreados++;
            }
        }

        foreach (var bx in doc.Descendants("banco"))
        {
            string codStr = bx.Element("codigo")?.Value?.Trim();
            string nom = bx.Element("nombre")?.Value?.Trim();
            if (!int.TryParse(codStr, out int cod) || string.IsNullOrEmpty(nom)) continue;

            var existente = Bancos.Buscar(b => b.Codigo == cod);
            if (existente != null)
            {
                Bancos.Actualizar(b => b.Codigo == cod, b => b.Nombre = nom);
                banAct++;
            }
            else
            {
                Bancos.Agregar(new Banco { Codigo = cod, Nombre = nom });
                banCreados++;
            }
        }

        GuardarDatos();
        return (cliCreados, cliAct, banCreados, banAct);
    }

    public (int nuevasF, int dupF, int errF, int nuevosP, int dupP, int errP)
        ProcesarTransacciones(string xmlContent)
    {
        int nuevasF = 0, dupF = 0, errF = 0;
        int nuevosP = 0, dupP = 0, errP = 0;

        XDocument doc = XDocument.Parse(xmlContent);

        // --- FACTURAS ---
        foreach (var fx in doc.Descendants("factura"))
        {
            string num = fx.Element("numeroFactura")?.Value?.Trim();
            string nit = fx.Element("NITcliente")?.Value?.Trim();
            string fec = fx.Element("fecha")?.Value?.Trim();
            string valStr = fx.Element("valor")?.Value?.Trim();

            if (string.IsNullOrEmpty(num) || string.IsNullOrEmpty(nit) ||
                string.IsNullOrEmpty(fec) || string.IsNullOrEmpty(valStr) ||
                !double.TryParse(valStr, out double val))
            { errF++; continue; }

            if (Clientes.Buscar(c => c.NIT == nit) == null)
            { errF++; continue; }

            if (Facturas.Existe(f => f.NumeroFactura == num))
            { dupF++; continue; }

            Facturas.Agregar(new Factura
            {
                NumeroFactura = num,
                NITCliente = nit,
                Fecha = fec,
                Valor = val,
                SaldoPendiente = val
            });
            nuevasF++;
        }

        // --- PAGOS (Fase 1: solo validación y almacenamiento) ---
        foreach (var px in doc.Descendants("pago"))
        {
            string codStr = px.Element("codigoBanco")?.Value?.Trim();
            string fec = px.Element("fecha")?.Value?.Trim();
            string nit = px.Element("NITcliente")?.Value?.Trim();
            string valStr = px.Element("valor")?.Value?.Trim();

            if (!int.TryParse(codStr, out int cod) || string.IsNullOrEmpty(fec) ||
                string.IsNullOrEmpty(nit) || string.IsNullOrEmpty(valStr) ||
                !double.TryParse(valStr, out double val))
            { errP++; continue; }

            if (Clientes.Buscar(c => c.NIT == nit) == null ||
                Bancos.Buscar(b => b.Codigo == cod) == null)
            { errP++; continue; }

            // Duplicados: en Fase 1 validamos por combinación simple
            if (Pagos.Existe(p => p.NITCliente == nit && p.Fecha == fec &&
                                   p.CodigoBanco == cod && p.Valor == val))
            { dupP++; continue; }

            Pagos.Agregar(new Pago
            {
                CodigoBanco = cod,
                Fecha = fec,
                NITCliente = nit,
                Valor = val
            });
            nuevosP++;
        }

        GuardarDatos();
        return (nuevasF, dupF, errF, nuevosP, dupP, errP);
    }

    // ==================== PERSISTENCIA XML ====================
    private void GuardarDatos()
    {
        GuardarClientes();
        GuardarBancos();
        GuardarFacturas();
        GuardarPagos();
    }

    private void CargarDatos()
    {
        CargarClientes();
        CargarBancos();
        CargarFacturas();
        CargarPagos();
    }

    private void GuardarClientes()
    {
        XElement root = new XElement("clientes");
        var n = Clientes.Cabeza;
        while (n != null)
        {
            root.Add(new XElement("cliente",
                new XElement("NIT", n.Dato.NIT),
                new XElement("nombre", n.Dato.Nombre),
                new XElement("saldoFavor", n.Dato.SaldoFavor)));
            n = n.Siguiente;
        }
        root.Save(_rutaClientes);
    }
    private void CargarClientes()
    {
        if (!File.Exists(_rutaClientes)) return;
        foreach (var e in XDocument.Load(_rutaClientes).Descendants("cliente"))
            Clientes.Agregar(new Cliente
            {
                NIT = e.Element("NIT")?.Value,
                Nombre = e.Element("nombre")?.Value,
                SaldoFavor = double.TryParse(e.Element("saldoFavor")?.Value, out double s) ? s : 0
            });
    }

    private void GuardarBancos()
    {
        XElement root = new XElement("bancos");
        var n = Bancos.Cabeza;
        while (n != null)
        {
            root.Add(new XElement("banco",
                new XElement("codigo", n.Dato.Codigo),
                new XElement("nombre", n.Dato.Nombre)));
            n = n.Siguiente;
        }
        root.Save(_rutaBancos);
    }
    private void CargarBancos()
    {
        if (!File.Exists(_rutaBancos)) return;
        foreach (var e in XDocument.Load(_rutaBancos).Descendants("banco"))
            if (int.TryParse(e.Element("codigo")?.Value, out int c))
                Bancos.Agregar(new Banco { Codigo = c, Nombre = e.Element("nombre")?.Value });
    }

    private void GuardarFacturas()
    {
        XElement root = new XElement("facturas");
        var n = Facturas.Cabeza;
        while (n != null)
        {
            root.Add(new XElement("factura",
                new XElement("numeroFactura", n.Dato.NumeroFactura),
                new XElement("NITcliente", n.Dato.NITCliente),
                new XElement("fecha", n.Dato.Fecha),
                new XElement("valor", n.Dato.Valor),
                new XElement("saldoPendiente", n.Dato.SaldoPendiente)));
            n = n.Siguiente;
        }
        root.Save(_rutaFacturas);
    }
    private void CargarFacturas()
    {
        if (!File.Exists(_rutaFacturas)) return;
        foreach (var e in XDocument.Load(_rutaFacturas).Descendants("factura"))
        {
            double.TryParse(e.Element("valor")?.Value, out double v);
            double.TryParse(e.Element("saldoPendiente")?.Value ?? e.Element("valor")?.Value, out double s);
            Facturas.Agregar(new Factura
            {
                NumeroFactura = e.Element("numeroFactura")?.Value,
                NITCliente = e.Element("NITcliente")?.Value,
                Fecha = e.Element("fecha")?.Value,
                Valor = v,
                SaldoPendiente = s
            });
        }
    }

    private void GuardarPagos()
    {
        XElement root = new XElement("pagos");
        var n = Pagos.Cabeza;
        while (n != null)
        {
            root.Add(new XElement("pago",
                new XElement("codigoBanco", n.Dato.CodigoBanco),
                new XElement("fecha", n.Dato.Fecha),
                new XElement("NITcliente", n.Dato.NITCliente),
                new XElement("valor", n.Dato.Valor)));
            n = n.Siguiente;
        }
        root.Save(_rutaPagos);
    }
    private void CargarPagos()
    {
        if (!File.Exists(_rutaPagos)) return;
        foreach (var e in XDocument.Load(_rutaPagos).Descendants("pago"))
            if (int.TryParse(e.Element("codigoBanco")?.Value, out int c))
                Pagos.Agregar(new Pago
                {
                    CodigoBanco = c,
                    Fecha = e.Element("fecha")?.Value,
                    NITCliente = e.Element("NITcliente")?.Value,
                    Valor = double.TryParse(e.Element("valor")?.Value, out double v) ? v : 0
                });
    }
}