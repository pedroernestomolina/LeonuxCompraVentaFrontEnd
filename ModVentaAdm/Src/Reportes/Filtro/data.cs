﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Reportes.Filtro
{
    
    public class data
    {

        private OOB.Sucursal.Entidad.Ficha _sucursal;
        private general _cliente;
        private Gestion.Estatus _estatus;
        private DateTime? _desde;
        private DateTime? _hasta;
        private int? _mesRelacion;
        private int? _anoRelacion;
        private bool? _tipoDocFactura;
        private bool? _tipoDocNtDebito;
        private bool? _tipoDocNtCredito;
        private bool? _tipoDocNtEntrega;
        private bool _validarTipoDocumento;


        public string IdSucursal 
        { 
            get 
            {
                var rt = "";
                if (Sucursal != null) { rt = Sucursal.auto; }
                return rt;
            } 
        }
        public OOB.Sucursal.Entidad.Ficha Sucursal { get { return _sucursal; } }
        public general Cliente { get { return _cliente; } }
        public DateTime? Desde { get { return _desde; } }
        public DateTime? Hasta { get { return _hasta; } }
        public bool? TipoDocFactura { get { return _tipoDocFactura; } }
        public bool? TipoDocNtDebito { get { return _tipoDocNtDebito; } }
        public bool? TipoDocNtCredito { get { return _tipoDocNtCredito; } }
        public bool? TipoDocNtEntrega { get { return _tipoDocNtEntrega; } }
        public string ClienteNombre 
        {
            get 
            {
                var rt = "";
                if (_cliente != null) { rt = _cliente.descripcion; }
                return rt;
            }
        }
        public string ClienteId
        {
            get
            {
                var rt = "";
                if (_cliente != null) { rt = _cliente.auto; }
                return rt;
            }
        }


        public data()
        {
            limpiar();
        }


        private void limpiar()
        {
            _sucursal = null;
            _estatus = null;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _mesRelacion = null;
            _anoRelacion = null;
            _tipoDocFactura = null;
            _tipoDocNtDebito = null;
            _tipoDocNtCredito = null;
            _tipoDocNtEntrega = null;
            _validarTipoDocumento = false;
            _cliente = null;
        }

        public void setSucursal(OOB.Sucursal.Entidad.Ficha ficha)
        {
            _sucursal = ficha;
        }

        public void setEstatus(Gestion.Estatus ficha)
        {
            _estatus = ficha;
        }

        public void setFechaDesde(DateTime desde)
        {
            _desde = desde.Date;
        }

        public void setFechaHasta(DateTime hasta)
        {
            _hasta = hasta.Date;
        }

        public void Inicializa()
        {
            limpiar();
        }

        public void setMesRelacion(int p)
        {
            _mesRelacion = p;
        }

        public void setAnoRelacion(int p)
        {
            _anoRelacion = p;
        }

        public bool IsOk()
        {
            var rt = true;

            var xdesde = DateTime.Now.Date;
            var xhasta = DateTime.Now.Date;
            if (_desde.HasValue) 
            {
                xdesde = _desde.Value.Date;
            }
            if (_hasta.HasValue)
            {
                xhasta= _hasta.Value.Date;
            }
            if (xdesde > xhasta)
            {
                Helpers.Msg.Error("PROBLEMAS CON FECHAS INCORRECTAS");
                return false;
            }

            if (_validarTipoDocumento) 
            {
                if (_tipoDocFactura == null && _tipoDocNtDebito == null && _tipoDocNtCredito == null && _tipoDocNtEntrega == null)
                {
                    Helpers.Msg.Error("PROBLEMAS CON TIPO DOCUMENTO");
                    return false;
                }
            }

            return rt;
        }

        public void setTipoDocFactura(bool p)
        {
            _tipoDocFactura = p;
        }

        public void setTipoDocNtDebito(bool p)
        {
            _tipoDocNtDebito= p;
        }

        public void setTipoDocNtCredito(bool p)
        {
            _tipoDocNtCredito= p;
        }

        public void setTipoDocNtEntrega(bool p)
        {
            _tipoDocNtEntrega= p;
        }

        public void setValidarTipoDocumento(bool p)
        {
            _validarTipoDocumento = p;
        }

        public void setCliente(string id, string desc)
        {
            if (_cliente ==null)
                _cliente=new general(id,desc); 
            else
            {
                _cliente.limpiar();
            }
            _cliente.setficha(id, desc);
        }

        public void LimpiarCliente()
        {
            _cliente = null;
        }

    }

}