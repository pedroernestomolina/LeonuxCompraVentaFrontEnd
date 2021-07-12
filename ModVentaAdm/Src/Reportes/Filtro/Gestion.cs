using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Reportes.Filtro
{
    
    public class Gestion
    {

        public class Estatus 
        {

            public string Id { get; set; }
            public string Descripcion { get; set; }


            public Estatus()
            {
                Id = "";
                Descripcion = "";
            }

            public Estatus(string id, string desc)
            {
                Id = id;
                Descripcion = desc;
            }

        }

        private IFiltro _filtro;
        private List<OOB.Sucursal.Entidad.Ficha> _lSucursal;
        private List<Estatus> _lEstatus;
        private BindingSource _bsSucursal;
        private BindingSource _bsEstatus;
        private data _data;
        private bool _isOk;
        private bool _procesarIsOk;
        private Cliente.Lista.Gestion _gestionClienteLista;


        public BindingSource SourceSucursal { get { return _bsSucursal; } }
        public BindingSource SourceEstatus { get { return _bsEstatus; } }
        public bool ActivarEstatus { get { return _filtro.ActivarEstatus; } }
        public bool ActivarDesdeHasta { get { return _filtro.ActivarDesdeHasta; } }
        public bool ActivarSucursal { get { return _filtro.ActivarSucursal; } }
        public bool ActivarMesAnoRelacion { get { return _filtro.ActivarMesAnoRelacion; } }
        public bool ActivarCliente { get { return _filtro.ActivarCliente; } }
        public bool ActivarTipoDocumento { get { return _filtro.ActivarTipoDocumento; } }
        public bool IsOk { get { return _isOk; } }
        public data Data { get { return _data; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }
        //
        public DateTime FechaDesde { get { return _data.Desde.Value; } }
        public DateTime FechaHasta { get { return _data.Hasta.Value; } }
        public object IdSucursal { get { return _data.IdSucursal; } }
        public bool ClienteSeleccionadoIsOK { get { return _data.Cliente != null ? true : false; } }
        public string NombreCliente { get { return _data.ClienteNombre; } }
        public string IdCliente { get { return _data.ClienteId; } }


        public Gestion()
        {
            _data = new data();
            _lSucursal = new List<OOB.Sucursal.Entidad.Ficha>();
            _lEstatus = new List<Estatus>();
            _bsSucursal = new BindingSource();
            _bsSucursal.DataSource = _lSucursal;
            _bsEstatus = new BindingSource();
            _bsEstatus.DataSource = _lEstatus;
            _gestionClienteLista = new Cliente.Lista.Gestion();
        }
        

        public void Inicializa()
        {
            _isOk = false;
            _procesarIsOk = false;
            _data.Inicializa();
        }

        public bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            _lSucursal.Clear();
            _lSucursal.AddRange(rt1.ListaD.OrderBy(o => o.nombre).ToList());
            _bsSucursal.CurrencyManager.Refresh();

            _lEstatus.Clear();
            _lEstatus.Add(new Estatus("01", "Activo"));
            _lEstatus.Add(new Estatus("02", "Anulado"));
            _bsEstatus.CurrencyManager.Refresh();

            return rt;
        }

        FiltroFrm frm;
        public void Inicia()
        {
            if (frm == null) 
            {
                frm = new FiltroFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void setFiltros(IFiltro filtro)
        {
            _filtro = filtro;
        }

        public void setSucursal(string p)
        {
            _data.setSucursal(_lSucursal.FirstOrDefault(f => f.auto == p));
        }

        public void setEstatus(string p)
        {
            _data.setEstatus(_lEstatus.FirstOrDefault(f => f.Id == p));
        }

        public void setFechaDesde(DateTime desde)
        {
            _data.setFechaDesde(desde);
        }

        public void setFechaHasta(DateTime hasta)
        {
            _data.setFechaHasta(hasta);
        }

        public void setMesRelacion(int p)
        {
            _data.setMesRelacion(p);
        }

        public void setAnoRelacion(int p)
        {
            _data.setAnoRelacion(p);
        }

        public void Filtrar()
        {
            _isOk = false;
            _procesarIsOk = false;
            _data.setValidarTipoDocumento(_filtro.ValidarTipoDocumento);

            if (_data.IsOk())
            {
                _isOk = true;
                _procesarIsOk = true;
            }
        }

        public void Salir()
        {
            _isOk = true;
        }

        public void setTipoDocFactura(bool p)
        {
            _data.setTipoDocFactura(p);
        }

        public void setTipoDocNtDebito(bool p)
        {
            _data.setTipoDocNtDebito(p);
        }

        public void setTipoDocNtCredito(bool p)
        {
            _data.setTipoDocNtCredito(p);
        }

        public void setTipoDocNtEntrega(bool p)
        {
            _data.setTipoDocNtEntrega(p);
        }

        private string _cliente;
        public void setCliente(string p)
        {
            _cliente = p.Trim();
        }

        public void BuscarCliente()
        {
            if (_cliente != "")
            {
                _gestionClienteLista.Inicializa();
                _gestionClienteLista.setBuscar(_cliente);
                _gestionClienteLista.Inicia();
                if (_gestionClienteLista.ItemSeleccionadoIsOk)
                {
                    _data.setCliente(_gestionClienteLista.ItemSeleccionado.auto, _gestionClienteLista.ItemSeleccionado.razonSocial);
                }
            }
        }

        public void LimpiarCliente()
        {
            _cliente = "";
            _data.LimpiarCliente();
        }

    }

}