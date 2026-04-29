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
    public Cola<Pago> ColaPagos { get; private set; }

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
        ColaPagos = new Cola<Pago>();

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
        ColaPagos.Limpiar();
        GuardarDatos();
    }

    // ==================== CONFIGURACIÓN ====================
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

    // ==================== TRANSACCIONES ====================
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

        // --- PAGOS: Validar y encolar en Cola propia ---
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

            if (Pagos.Existe(p => p.NITCliente == nit && p.Fecha == fec &&
                                   p.CodigoBanco == cod && p.Valor == val))
            { dupP++; continue; }

            var pago = new Pago
            {
                CodigoBanco = cod,
                Fecha = fec,
                NITCliente = nit,
                Valor = val
            };

            Pagos.Agregar(pago);
            ColaPagos.Encolar(pago);
            nuevosP++;
        }

        // --- PROCESAR COLA DE PAGOS (abono a facturas) ---
        ProcesarColaPagos();

        GuardarDatos();
        return (nuevasF, dupF, errF, nuevosP, dupP, errP);
    }

    private void ProcesarColaPagos()
    {
        while (!ColaPagos.EstaVacia)
        {
            var pago = ColaPagos.Desencolar();
            AplicarPago(pago);
        }
    }

    private void AplicarPago(Pago pago)
    {
        var cliente = Clientes.Buscar(c => c.NIT == pago.NITCliente);
        if (cliente == null) return;

        double montoDisponible = pago.Valor + cliente.SaldoFavor;
        cliente.SaldoFavor = 0;

        // Obtener facturas pendientes del cliente
        var facturasPendientes = new ListaEnlazada<Factura>();
        var n = Facturas.Cabeza;
        while (n != null)
        {
            if (n.Dato.NITCliente == pago.NITCliente && n.Dato.SaldoPendiente > 0)
                facturasPendientes.Agregar(n.Dato);
            n = n.Siguiente;
        }

        // Ordenar por fecha: más antigua primero
        facturasPendientes.Ordenar((a, b) => CompararFechas(a.Fecha, b.Fecha));

        // Abonar a facturas más antiguas
        var fn = facturasPendientes.Cabeza;
        while (fn != null && montoDisponible > 0)
        {
            var factura = fn.Dato;
            if (montoDisponible >= factura.SaldoPendiente)
            {
                montoDisponible -= factura.SaldoPendiente;
                factura.SaldoPendiente = 0;
            }
            else
            {
                factura.SaldoPendiente -= montoDisponible;
                montoDisponible = 0;
            }
            fn = fn.Siguiente;
        }

        // Si sobra dinero, saldo a favor
        cliente.SaldoFavor = montoDisponible;
    }

    private int CompararFechas(string f1, string f2)
    {
        // dd/mm/yyyy -> comparar como yyyymmdd
        var p1 = f1.Split('/');
        var p2 = f2.Split('/');
        string s1 = p1[2] + p1[1] + p1[0];
        string s2 = p2[2] + p2[1] + p2[0];
        return string.Compare(s1, s2);
    }

    // ==================== ESTADO DE CUENTA ====================
    public XDocument ObtenerEstadoCuenta(string nitFiltro)
    {
        var root = new XElement("estadosCuenta");

        var nodoCliente = Clientes.Cabeza;
        while (nodoCliente != null)
        {
            var cliente = nodoCliente.Dato;
            if (!string.IsNullOrEmpty(nitFiltro) && cliente.NIT != nitFiltro)
            {
                nodoCliente = nodoCliente.Siguiente;
                continue;
            }

            var transacciones = new ListaEnlazada<TransaccionCuenta>();

            // Cargos = Facturas
            var nf = Facturas.Cabeza;
            while (nf != null)
            {
                if (nf.Dato.NITCliente == cliente.NIT)
                {
                    transacciones.Agregar(new TransaccionCuenta
                    {
                        Fecha = nf.Dato.Fecha,
                        Cargo = nf.Dato.Valor,
                        Abono = 0,
                        Referencia = $"Fact.#{nf.Dato.NumeroFactura}"
                    });
                }
                nf = nf.Siguiente;
            }

            // Abonos = Pagos
            var np = Pagos.Cabeza;
            while (np != null)
            {
                if (np.Dato.NITCliente == cliente.NIT)
                {
                    var banco = Bancos.Buscar(b => b.Codigo == np.Dato.CodigoBanco);
                    transacciones.Agregar(new TransaccionCuenta
                    {
                        Fecha = np.Dato.Fecha,
                        Cargo = 0,
                        Abono = np.Dato.Valor,
                        Referencia = banco?.Nombre ?? "Banco"
                    });
                }
                np = np.Siguiente;
            }

            // Ordenar de más reciente a más antigua
            transacciones.Ordenar((a, b) => CompararFechas(b.Fecha, a.Fecha));

            double saldoActual = 0;
            var nt = transacciones.Cabeza;
            while (nt != null)
            {
                saldoActual += nt.Dato.Cargo;
                saldoActual -= nt.Dato.Abono;
                nt = nt.Siguiente;
            }
            saldoActual = Math.Round(saldoActual, 2);

            var xmlCliente = new XElement("cliente",
                new XElement("NIT", cliente.NIT),
                new XElement("nombre", cliente.Nombre),
                new XElement("saldoActual", saldoActual.ToString("F2")),
                new XElement("transacciones")
            );

            var nt2 = transacciones.Cabeza;
            while (nt2 != null)
            {
                xmlCliente.Element("transacciones").Add(
                    new XElement("transaccion",
                        new XElement("fecha", nt2.Dato.Fecha),
                        new XElement("cargo", nt2.Dato.Cargo.ToString("F2")),
                        new XElement("abono", nt2.Dato.Abono.ToString("F2")),
                        new XElement("referencia", nt2.Dato.Referencia)));
                nt2 = nt2.Siguiente;
            }

            root.Add(xmlCliente);
            nodoCliente = nodoCliente.Siguiente;
        }

        return new XDocument(root);
    }

    // ==================== RESUMEN DE PAGOS (para gráficas Fase 3) ====================
    public XDocument ObtenerResumenPagos(int mes, int anio)
    {
        var root = new XElement("resumenPagos");
        root.Add(new XElement("mes", mes.ToString("D2")));
        root.Add(new XElement("anio", anio.ToString()));

        var bancosNode = new XElement("bancos");
        var nb = Bancos.Cabeza;
        while (nb != null)
        {
            double total = 0;
            var np = Pagos.Cabeza;
            while (np != null)
            {
                if (np.Dato.CodigoBanco == nb.Dato.Codigo)
                {
                    var partes = np.Dato.Fecha.Split('/');
                    if (partes.Length == 3 &&
                        int.Parse(partes[1]) == mes &&
                        int.Parse(partes[2]) == anio)
                    {
                        total += np.Dato.Valor;
                    }
                }
                np = np.Siguiente;
            }

            bancosNode.Add(new XElement("banco",
                new XElement("codigo", nb.Dato.Codigo),
                new XElement("nombre", nb.Dato.Nombre),
                new XElement("total", total.ToString("F2"))));

            nb = nb.Siguiente;
        }

        root.Add(bancosNode);
        return new XDocument(root);
    }

    // ==================== PERSISTENCIA ====================
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
                new XElement("saldoFavor", n.Dato.SaldoFavor.ToString("F2"))));
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
                new XElement("valor", n.Dato.Valor.ToString("F2")),
                new XElement("saldoPendiente", n.Dato.SaldoPendiente.ToString("F2"))));
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
                new XElement("valor", n.Dato.Valor.ToString("F2"))));
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