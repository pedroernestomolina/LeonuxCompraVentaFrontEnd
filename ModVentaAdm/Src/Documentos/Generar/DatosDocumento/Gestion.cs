﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar.DatosDocumento
{
    
    public class Gestion
    {

        private data _data;
        private bool _abandonarCambiosIsOk;
        private bool _aceptarDatosIsOK;
        private List<ficha> _lCobrador;
        private BindingSource _bsCobrador;
        private List<ficha> _lCondPago;
        private BindingSource _bsCondPago;
        private List<ficha> _lDeposito;
        private BindingSource _bsDeposito;
        private List<ficha> _lTransporte;
        private BindingSource _bsTransporte;
        private List<ficha> _lVendedor;
        private BindingSource _bsVendedor;
        private List<ficha> _lSucursal;
        private BindingSource _bsSucursal;
        private IDatosDocumento _habDatosDoc;
        private BuscarCliente.Gestion _buscarCliente;
        private bool _habilitarDeposito;
        private bool _habilitarSucursal;
        private bool _habilitarBusquedaCliente;
        private bool _isModoRegistrar;
        private int _idRegDocTemporal;


        public bool AceptarDatosIsOK { get { return _aceptarDatosIsOK; } }
        public bool AbandonarCambiosIsOk { get { return _abandonarCambiosIsOk; } }
        public BindingSource SourceCobrador { get { return _bsCobrador; } }
        public BindingSource SourceCondPago { get { return _bsCondPago; } }
        public BindingSource SourceDeposito { get { return _bsDeposito; } }
        public BindingSource SourceTransporte { get { return _bsTransporte; } }
        public BindingSource SourceVendedor { get { return _bsVendedor; } }
        public BindingSource SourceSucursal { get { return _bsSucursal; } }
        public string DataCliente { get { return _data.Cliente; } }
        public string DataFecha { get { return _data.Fecha.ToShortDateString(); } }
        public string DataFechaVence { get { return _data.FechaVence.ToShortDateString(); } }
        public string DataOrdenCompra { get { return _data.OrdenCompra; } }
        public string DataPedido { get { return _data.Pedido; } }
        public string DataFechaPedido { get { return _data.FechaPedido; } }
        public string DataDirDespacho { get { return _data.DirDespacho; } }
        public string DataDiasValidez { get { return _data.DiasValidez.ToString(); } }
        public string DataDiasCredito { get { return _data.DiasCredito.ToString(); } }
        public string DataIdCobrador { get { return _data.IdCobrador; } }
        public string DataIdCondPago { get { return _data.IdCondPago; } }
        public string DataIdSucursal { get { return _data.IdSucursal; } }
        public string DataIdTransporte { get { return _data.IdTransporte; } }
        public string DataIdVendedor { get { return _data.IdVendedor; } }
        public string DataIdDeposito { get { return _data.IdDeposito; } }
        public string DataNotasDoc { get { return _data.NotasDoc; } }
        public bool HabilitarDiasValidez { get { return _habDatosDoc.HabilitarDiasValidez; } }
        public bool HabilitarDirDespacho { get { return _habDatosDoc.HabilitarDirDespacho; } }
        public bool HabilitarOrdenCompra { get { return _habDatosDoc.HabilitarOrdenCompra; } }
        public bool HabilitarPedido { get { return _habDatosDoc.HabilitarPedido; } }
        public bool HabilitarDeposito { get { return _habilitarDeposito; } }
        public bool HabilitarSucursal { get { return _habilitarSucursal; } }
        public bool HabilitarBusquedaCliente { get { return _habilitarBusquedaCliente; } }
        public bool CondicionPagoIsCredito { get { return _data.CondicionPagoIsCredito; } }
        public string ClienteRif { get { return _data.ClienteRif; } }
        public string ClienteCodigo { get { return _data.ClienteCodigo; } }
        public string ClienteRazonSocialDireccion { get { return _data.ClienteRazonSocialDireccion; } }
        public OOB.Maestro.Cliente.Entidad.Ficha EntidadCliente { get { return _data.EntidadCliente; } }
        public string DataCondPago { get { return _data.CondicionPago; } }
        public string DataDeposito { get { return _data.Deposito; } }
        public string DataSucursal { get { return _data.Sucursal; } }
        public string DataIdSistTipoDocumento { get { return _data.IdSistTipoDocumento; } }
        public decimal DataFactorDivisa { get { return _data.FactorDivisa; } }
        public string DataIdEquipo { get { return _data.IdEquipo; } }
        public string DataSistTipoDocumento { get { return _data.SistTipoDocumento; } }
        public int IdRegDocTemporal { get { return _idRegDocTemporal; } }
        

        public Gestion() 
        {
            _idRegDocTemporal = -1;
            _isModoRegistrar = false;

            _data = new data();
            _abandonarCambiosIsOk = false;
            _aceptarDatosIsOK = false;
            
            _lCondPago = new List<ficha>();
            _bsCondPago = new BindingSource();
            _bsCondPago.DataSource = _lCondPago;
            
            _lVendedor = new List<ficha>();
            _bsVendedor = new BindingSource();
            _bsVendedor.DataSource = _lVendedor;
            
            _lSucursal = new List<ficha>();
            _bsSucursal = new BindingSource();
            _bsSucursal.DataSource = _lSucursal;
            
            _lTransporte = new List<ficha>();
            _bsTransporte = new BindingSource();
            _bsTransporte.DataSource = _lTransporte;
            
            _lDeposito = new List<ficha>();
            _bsDeposito = new BindingSource();
            _bsDeposito.DataSource = _lDeposito;

            _lCobrador = new List<ficha>();
            _bsCobrador = new BindingSource();
            _bsCobrador.DataSource = _lCobrador;

            _buscarCliente = new BuscarCliente.Gestion();
        }


        public void Inicializa()
        {
            _isModoRegistrar = false;
            _idRegDocTemporal = -1;
            _abandonarCambiosIsOk = false;
            _aceptarDatosIsOK = false;
            _data.Inicializa();
        }

        DatosDocumento.DatosDocFrm _frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (_frm == null) 
                {
                    _frm = new DatosDocFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();

            }
        }

        private bool CargarData()
        {
            var rt = true;
            //
            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _lSucursal.Clear();
            _lSucursal = r01.ListaD.OrderBy(o=>o.nombre).Select(s =>
            {
                return new ficha(s.auto, s.nombre, s.codigo);
            }).ToList();
            _bsSucursal.DataSource = _lSucursal;
            _bsSucursal.CurrencyManager.Refresh();
            //
            var r02 = Sistema.MyData.Sistema_Vendedor_GetLista();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _lVendedor.Clear();
            _lVendedor = r02.ListaD.OrderBy(o=>o.nombre).Select(s =>
            {
                return new ficha(s.id, s.nombre);
            }).ToList();
            _bsVendedor.DataSource = _lVendedor;
            _bsVendedor.CurrencyManager.Refresh();
            //
            var r03 = Sistema.MyData.Sistema_Cobrador_GetLista();
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _lCobrador.Clear();
            _lCobrador = r03.ListaD.OrderBy(o=>o.nombre).Select(s =>
            {
                return new ficha(s.id, s.nombre);
            }).ToList();
            _bsCobrador.DataSource = _lCobrador;
            _bsCobrador.CurrencyManager.Refresh();
            //
            var r04 = Sistema.MyData.Sistema_Transporte_GetLista();
            if (r04.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            _lTransporte.Clear();
            _lTransporte = r04.ListaD.OrderBy(o=>o.nombre).Select(s =>
            {
                return new ficha(s.id, s.nombre);
            }).ToList();
            _bsTransporte.DataSource = _lTransporte;
            _bsTransporte.CurrencyManager.Refresh();
            //
            var r06 = Sistema.MyData.FechaServidor ();
            if (r06.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            _data.setFecha(r06.Entidad);
            //
            _lCondPago.Clear();
            _lCondPago.Add(new ficha("01", "CONTADO"));
            _lCondPago.Add(new ficha("02", "CREDITO"));
            _bsCondPago.CurrencyManager.Refresh();
            
            return rt;
        }

        public void AbandonarCambios()
        {
            _abandonarCambiosIsOk = false;
            var msg = "Abandonar Cambios En Cuestión ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                _abandonarCambiosIsOk= true;
                if (!_aceptarDatosIsOK)
                {
                    _data.Inicializa();
                }
            }
        }

        public void setCondPago(string id)
        {
            _data.setCondPago(_lCondPago.First(f=>f.id==id));
        }

        public void setSucursal(string id)
        {
            var suc= _lSucursal.First(f => f.id == id);
            _data.setSucursal(suc);
            if (id != "")
                CargarDepositosSucursal(suc.cod);
        }

        private void CargarDepositosSucursal(string p)
        {
            _lDeposito.Clear();
            var filtro = new OOB.Sistema.Deposito.Lista.Filtro();
            filtro.PorCodigoSuc = p;
            var r01 = Sistema.MyData.Deposito_GetLista(filtro);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _lDeposito = r01.ListaD.OrderBy(o => o.nombre).Select(s =>
            {
                return new ficha(s.id, s.nombre);
            }).ToList();
            _bsDeposito.DataSource = _lDeposito;
            _bsDeposito.CurrencyManager.Refresh();
        }

        public void setCobrador(string id)
        {
            _data.setCobrador(_lCobrador.First(f => f.id == id));
        }

        public void setVendedor(string id)
        {
            _data.setVendedor(_lVendedor.First(f => f.id == id));
        }

        public void setTransporte(string id)
        {
            _data.setTransporte(_lTransporte.First(f => f.id == id));
        }

        public void setDeposito(string id)
        {
            if (id == "")
            {
                _data.LimpiarDeposito();
                return;
            }
            _data.setDeposito(_lDeposito.First(f => f.id == id));
        }

        public void setDiasCredito(int cnt)
        {
            _data.setDiasCredito(cnt);
        }

        public void setDiasValidez(int cnt)
        {
            _data.setDiasValidez(cnt);
        }

        public void setDirDespacho(string p)
        {
            _data.setDirDespacho(p);
        }

        public void setOrdenCompra(string p)
        {
            _data.setOrdenCompra(p);
        }

        public void setPedido(string p)
        {
            _data.setPedido(p);
        }

        public void setHabilitarDatosDoc(IDatosDocumento datosDocumento)
        {
            _habDatosDoc = datosDocumento;
        }

        public void AceptarDatos()
        {
            if (_data.ValidarDatos())
            {
                if (_isModoRegistrar)
                {
                    var ficha = new OOB.Venta.Temporal.Encabezado.Registrar.Ficha()
                    {
                        autoCliente = EntidadCliente.id,
                        autoDeposito = DataIdDeposito,
                        autoSistDocumento = DataIdSistTipoDocumento,
                        autoSucursal = DataIdSucursal,
                        autoUsuario = Sistema.Usuario.id,
                        ciRifCliente = EntidadCliente.ciRif,
                        estatusPendiente = "",
                        factorDivisa = DataFactorDivisa,
                        idEquipo = DataIdEquipo,
                        monto = 0m,
                        montoDivisa = 0m,
                        nombreDeposito = DataDeposito,
                        nombreSistDocumento = DataSistTipoDocumento,
                        nombreSucursal = DataSucursal,
                        nombreUsuario = Sistema.Usuario.nombre,
                        razonSocialCliente = EntidadCliente.razonSocial,
                        renglones = 0,
                    };
                    var r01 = Sistema.MyData.Venta_Temporal_Encabezado_Registrar(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _idRegDocTemporal = r01.Id;
                    _aceptarDatosIsOK = true;
                }
                else
                {
                    var ficha = new OOB.Venta.Temporal.Encabezado.Editar.Ficha()
                    {
                        id=_idRegDocTemporal,
                        autoCliente = EntidadCliente.id,
                        autoDeposito = DataIdDeposito,
                        autoSucursal = DataIdSucursal,
                        ciRifCliente = EntidadCliente.ciRif,
                        nombreDeposito = DataDeposito,
                        nombreSucursal = DataSucursal,
                        razonSocialCliente = EntidadCliente.razonSocial,
                    };
                    var r01 = Sistema.MyData.Venta_Temporal_Encabezado_Editar(ficha);
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _aceptarDatosIsOK = true;
                }
            }
        }

        public void BuscarCliente()
        {
            _buscarCliente.Inicializa();
            _buscarCliente.setActivarSeleccionItem(true);
            _buscarCliente.Inicia();
            if (_buscarCliente.ItemSeleccionadoIsOk) 
            {
                var r01 = Sistema.MyData.Cliente_GetFicha(_buscarCliente.ItemSeleccionado.Id);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _data.setCliente(r01.Entidad);
                setVendedor(r01.Entidad.idVendedor);
                setCobrador(r01.Entidad.idCobrador);
                setDirDespacho(r01.Entidad.dirDespacho);
                setDiasCredito(r01.Entidad.diasCredito);
                setCondPago("01");
                if (r01.Entidad.IsCreditoActivo)
                    setCondPago("02");
            }
        }

        public void Limpiar()
        {
            _abandonarCambiosIsOk = false;
            _aceptarDatosIsOK = false;
            _data.Inicializa();
        }

        public void setNotasDoc(string p)
        {
            _data.setNotasDoc(p);
        }

        public void setFactorDivisa(decimal TasaDivisa)
        {
            _data.setFactorDivisa(TasaDivisa);
        }

        public void setTipoDocumento(OOB.Sistema.TipoDocumento.Entidad.Ficha ficha)
        {
            _data.setTipoDocumento(ficha);
        }

        public void setIdEquipo(string p)
        {
            _data.setIdEquipo(p);
        }

        public void setIsModoRegistrar(bool p)
        {
            _isModoRegistrar = p;
        }

        public void setHabilitarSucursal(bool p)
        {
            _habilitarSucursal= p;
        }

        public void setHabilitarDeposito(bool p)
        {
            _habilitarDeposito = p;
        }

        public void setHabilitarBusquedaCliente(bool p)
        {
            _habilitarBusquedaCliente = p;
        }

    }

}