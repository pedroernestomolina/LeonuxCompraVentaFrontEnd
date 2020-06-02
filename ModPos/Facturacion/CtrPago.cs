using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Facturacion
{
    
    public class CtrPago
    {


        private OOB.LibVenta.PosOffline.Permiso.Pos.Ficha _permisos;
        private ClaveSeguridad.Seguridad _seguridad;
        private CtrCliente _cliente;


        public bool PagoIsOk { get; set; }
        public Pago.Pago Pago { get; set; }


        public string FichaCliente 
        {
            get
            {
                return _cliente.Ficha.Data;
            }
        }


        public CtrPago(ClaveSeguridad.Seguridad seguridad, CtrCliente cliente)
        {
            Pago = new Facturacion.Pago.Pago();
            _seguridad = seguridad;
            _cliente = cliente;
        }


        public void Pagar(OOB.LibVenta.PosOffline.Permiso.Pos.Ficha permiso, decimal monto, decimal tasaCambio) 
        {
            _permisos = permiso;
            Pago.setMontoPagar(monto);
            Pago.setTasaCambio(tasaCambio);

            var frm = new Facturacion.Pago.PagoFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void setPermiso(OOB.LibVenta.PosOffline.Permiso.Pos.Ficha permiso) 
        {
            _permisos = permiso;
        }

        public void Calculadora() 
        {
            Helpers.Utilitis.Calculadora();
        }

        public bool Procesar() 
        {
            var rt = false;
            rt=Pago.Procesar();
            if (rt) 
            {
                PagoIsOk = true;
            }
            return rt;
        }

        public void ActivarDescuento() 
        {
            var seguir = true;
            if (_permisos.DarDesctoGlobal.RequiereClave)
            {
                seguir = _seguridad.SolicitarClave();
            }
            if (seguir)
            {
                Pago.DarDescuento();
            }
        }

        public bool ActivarCredito() 
        {
            var rt = false;

            var seguir = true;
            if (_permisos.CtaCredito.RequiereClave)
            {
                seguir = _seguridad.SolicitarClave();
            }
            if (seguir)
            {
                if (Pago.setDocumentoCredito())
                {
                    if (Pago.ProcesarCredito())
                    {
                        PagoIsOk = true;
                        rt = true;
                    }
                }
            }

            return rt;
        }

    }

}