﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Src.Documentos.Generar.DatosDocumento
{
    
    public class data
    {

        private DateTime _fecha;
        private int _diasCredito;
        private string _ordenCompra;
        private string _pedido;
        private string _fechaPedido;
        private string _dirDespacho;
        private int _diasValidez;
        private ficha _cliente;
        private ficha _sucursal;
        private ficha _condPago;
        private ficha _deposito;
        private ficha _vendedor;
        private ficha _cobrador;
        private ficha _transporte;
        private OOB.Maestro.Cliente.Entidad.Ficha _entidadCliente;


        public string Cliente { get { return _cliente.desc; } }
        public DateTime Fecha { get { return _fecha; } }
        public DateTime FechaVence { get { return _fecha.AddDays(_diasCredito); } }
        public string OrdenCompra { get { return _ordenCompra; } }
        public string Pedido { get { return _pedido; } }
        public string FechaPedido { get { return _fechaPedido; } }
        public string DirDespacho { get { return _dirDespacho; } }
        public int DiasValidez { get { return _diasValidez; } }
        public int DiasCredito { get { return _diasCredito; } }
        public string IdCobrador { get { return _cobrador.id; } }
        public string IdVendedor{ get { return _vendedor.id; } }
        public string IdDeposito { get { return _deposito.id; } }
        public string Deposito { get { return _deposito.desc; } }
        public string IdSucursal { get { return _sucursal.id; } }
        public string Sucursal { get { return _sucursal.desc; } }
        public string IdTransporte { get { return _transporte.id; } }
        public string IdCondPago { get { return _condPago.id; } }
        public string IdCliente { get { return _cliente.id; } }
        public bool CondicionPagoIsCredito { get { return _condPago.id == "02"; } }
        public OOB.Maestro.Cliente.Entidad.Ficha EntidadCliente { get { return _entidadCliente; } }
        public string ClienteRif 
        { 
            get 
            {
                var r = "Rif: ";
                if (_entidadCliente != null)
                    r += _entidadCliente.ciRif.Trim();
                return r;
            } 
        }
        public string ClienteCodigo
        {
            get
            {
                var r = "Codigo: ";
                if (_entidadCliente != null)
                    r += _entidadCliente.codigo.Trim();
                return r;
            }
        }
        public string ClienteRazonSocialDireccion
        {
            get
            {
                var r = "";
                if (_entidadCliente != null)
                {
                    r += _entidadCliente.razonSocial.Trim().ToUpper() + Environment.NewLine + _entidadCliente.dirFiscal.Trim();
                }
                return r;
            }
        }

        public string CondicionPago
        {
            get
            {
                var r = "CONTADO ";
                if (CondicionPagoIsCredito) 
                    r = "CREDITO ";
                r += _diasCredito.ToString().Trim() + " Dias";
                return r;
            }
        }


        public data()
        {
            Inicializa();
        }


        public void Inicializa()
        {
            _fecha = DateTime.Now.Date;
            _diasCredito = 0;
            _ordenCompra = "";
            _pedido = "";
            _fechaPedido = "";
            _dirDespacho = "";
            _diasValidez = 0;
            _cliente = new ficha();
            _condPago = new ficha();
            _sucursal = new ficha();
            _deposito = new ficha();
            _vendedor = new ficha();
            _cobrador = new ficha();
            _transporte = new ficha();
            _entidadCliente = null;
        }

        public void setCondPago(ficha ficha)
        {
            _condPago = ficha;
        }

        public void setSucursal(ficha ficha)
        {
            _sucursal = ficha;
        }

        public void setDiasCredito(int cnt)
        {
            _diasCredito = cnt;
        }

        public void setCobrador(ficha ficha)
        {
            _cobrador = ficha;
        }

        public void setVendedor(ficha ficha)
        {
            _vendedor = ficha;
        }

        public void setTransporte(ficha ficha)
        {
            _transporte = ficha;
        }

        public void setDeposito(ficha ficha)
        {
            _deposito = ficha;
        }

        public void setDiasValidez(int cnt)
        {
            _diasValidez = cnt;
        }

        public void setDirDespacho(string p)
        {
            _dirDespacho = p;
        }

        public void setOrdenCompra(string p)
        {
            _ordenCompra = p;
        }

        public void setPedido(string p)
        {
            _pedido = p;
        }

        public void setFecha(DateTime f)
        {
            _fecha = f;
        }

        public bool ValidarDatos() 
        {
            var r = true;

            if (_cliente.id == "")
            {
                Helpers.Msg.Error("CAMPO CLIENTE NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_sucursal.id == "") 
            {
                Helpers.Msg.Error("CAMPO SUCURSAL NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_condPago.id == "")
            {
                Helpers.Msg.Error("CAMPO CONDICION DE PAGO NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_deposito.id == "")
            {
                Helpers.Msg.Error("CAMPO DEPOSITO NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_vendedor.id == "")
            {
                Helpers.Msg.Error("CAMPO VENDEDOR NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_cobrador.id == "")
            {
                Helpers.Msg.Error("CAMPO COBRADOR NO PUEDE ESTAR VACIO");
                return false;
            }

            if (_transporte.id == "")
            {
                Helpers.Msg.Error("CAMPO TRANSORTE NO PUEDE ESTAR VACIO");
                return false;
            }

            return r;
        }

        public void setCliente(OOB.Maestro.Cliente.Entidad.Ficha ficha)
        {
            _cliente.id = ficha.id ;
            _cliente.desc = ficha.ciRif + Environment.NewLine + ficha.razonSocial;
            _entidadCliente = ficha;
        }

        public void LimpiarDeposito()
        {
            _deposito.Limpiar();
        }

    }

}