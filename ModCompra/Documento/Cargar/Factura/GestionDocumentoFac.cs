﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionDocumentoFac: Controlador.IGestionDocumento
    {

        private dataDocumento data;
        private BindingSource bsSucursal;
        private BindingSource bsDeposito;
        private List<OOB.LibCompra.Deposito.Data.Ficha> ldeposito;
        private List<OOB.LibCompra.Sucursal.Data.Ficha> lsucursal;
        private Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda preferenciaBusq;
        private bool _dataIsOk;
        private Proveedor.Listar.Gestion _gestionListaPrv;
        private decimal _tasaCambio;
        private Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda _preferencia;


        public string CadenaBuscar{get; set;}
        public string DocumentoNro { get { return data.documentoNro; } set { data.documentoNro = value; } }
        public string ControlNro { get { return data.controlNro; } set { data.controlNro = value; } }
        public string OrdenCompraNro { get { return data.ordenCompra; } set { data.ordenCompra= value; } }
        public int DiasCredito { get { return data.diasCredito; } set { data.diasCredito = value; } }
        public decimal FactorDivisa { get { return data.factorDivisa; } set { data.factorDivisa = value; } }
        public DateTime FechaEmision { get { return data.fechaEmision; } set { data.fechaEmision = value; } }
        public string Notas { get { return data.notas; } set { data.notas = value; } }
        public string MesRelacion { get { return data.mesRelacion; }  }
        public string AnoRelacion { get { return data.anoRelacion; }  }
        public DateTime FechaVencimiento { get { return data.fechaVencimiento; }  }
        public string RifProveedor { get { return data.ciRif; }  }
        public string RazonSocialProveedor { get { return data.nombreRazonSocial; }  }
        public string DireccionProveedor { get { return data.direccionFiscal; }  }
        public Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda PreferenciaBusquedaProveedor { get { return preferenciaBusq; } }
        public BindingSource SucursalSource { get { return bsSucursal; } }
        public BindingSource DepositoSource { get { return bsDeposito; } }
        public bool IsAceptarOk { get { return _dataIsOk; } }
        public bool ProveedorIsOk { get; set; }
        public bool LimpiarDatosIsOk { get; set; }
        public string DepositoNombre{get { return data.DepositoNombre; }}
        public string SucursalNombre{get { return data.SucursalNombre; }}
        public string IdSucursal 
        { 
            get { return data.IdSucursal; } 
            set
            {
                data.IdSucursal = value;
                data.Sucursal = lsucursal.FirstOrDefault(f => f.auto == value);
            } 
        }
        public string IdDeposito 
        { 
            get { return data.IdDeposito; } 
            set 
            { 
                data.IdDeposito = value;
                data.Deposito = ldeposito.FirstOrDefault(f => f.auto == value);
            } 
        }


        public GestionDocumentoFac()
        {
            _dataIsOk = false;
            ldeposito = new List<OOB.LibCompra.Deposito.Data.Ficha>();
            lsucursal = new List<OOB.LibCompra.Sucursal.Data.Ficha>();
            bsDeposito = new BindingSource();
            bsSucursal= new BindingSource();
            bsDeposito.DataSource = ldeposito;
            bsSucursal.DataSource = lsucursal;
            data = new dataDocumento();

            _gestionListaPrv= new Proveedor.Listar.Gestion();
            _gestionListaPrv.ItemSeleccionadoOk += _gestionListaPrv_ItemSeleccionadoOk;
        }

        private void _gestionListaPrv_ItemSeleccionadoOk(object sender, EventArgs e)
        {
            var autoPrv=_gestionListaPrv.ItemSeleccionado.auto;
            var r01 = Sistema.MyData.Proveedor_GetFicha(autoPrv);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            ProveedorIsOk = true;
            data.proveedor = r01.Entidad;
            _gestionListaPrv.CerrarFrm();
        }

        public bool CargarData()
        {
            var rt = true;

            var r00 = Sistema.MyData.FechaServidor();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return false;
            }

            var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _tasaCambio = r01.Entidad;

            var r02 = Sistema.MyData.Deposito_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            ldeposito.Clear();
            ldeposito.AddRange(r02.Lista);
            bsDeposito.CurrencyManager.Refresh();

            var r03 = Sistema.MyData.Sucursal_GetLista ();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            lsucursal.Clear();
            lsucursal.AddRange(r03.Lista);
            bsSucursal.CurrencyManager.Refresh();

            var r04 = Sistema.MyData.Configuracion_PreferenciaBusquedaProveedor();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            _preferencia = (Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda)r04.Entidad;
            preferenciaBusq = (Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda)r04.Entidad;

            data.setFechaServidor(r00.Entidad);
            data.setFactorDivisa( r01.Entidad);

            return rt;
        }

        public void Aceptar()
        {
            _dataIsOk=false;
            if (data.ValidarEntradas()) 
            {
                var msg = MessageBox.Show("Datos Correctos ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                    _dataIsOk = true;
            }
        }

        public void setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda metodo)
        {
            preferenciaBusq = metodo;
        }

        public void BuscarProveedor()
        {
            ProveedorIsOk = false;

            var metodo = OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.SnDefinir;
            switch (preferenciaBusq) 
            {
                case  Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.CiRif:
                    metodo = OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.CiRif;
                    break;
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Codigo:
                    metodo = OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.Codigo;
                    break;
                case Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda.Nombre:
                    metodo = OOB.LibCompra.Proveedor.Enumerados.EnumMetodoBusqueda.Nombre;
                    break;
            }

            var filtro = new OOB.LibCompra.Proveedor.Lista.Filtro()
            {
                MetodoBusqueda = metodo,
                cadena = CadenaBuscar,
            };
            var r01 = Sistema.MyData.Proveedor_GetLista(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _gestionListaPrv.setLista(r01.Lista);
            _gestionListaPrv.Inicia();
        }

        public void LimpiarDatos()
        {
            LimpiarDatosIsOk= false;
            var msg = MessageBox.Show("Estas Seguro de Limpiar Datos Cargados ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                LimpiarDatosIsOk = true;
                data.Limpiar();
                data.setFactorDivisa(_tasaCambio);
                preferenciaBusq = _preferencia;
            }
        }

    }

}