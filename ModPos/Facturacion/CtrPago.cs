using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion
{
    
    public class CtrPago
    {


        private OOB.LibVenta.PosOffline.Permiso.Pos.Ficha _permisos;
        private ClaveSeguridad.Seguridad _seguridad;
        private CtrCliente _cliente;


        public bool PagoIsOk { get; set; }
        public Pago.Pago Pago { get; set; }
        public string PagoElectronico_LOTE_1 { get { return Pago.PagoElectronico_LOTE(1); } }
        public string PagoElectronico_REF_1 { get { return Pago.PagoElectronico_REF(1); } }
        public string PagoElectronico_LOTE_2 { get { return Pago.PagoElectronico_LOTE(2); } }
        public string PagoElectronico_REF_2 { get { return Pago.PagoElectronico_REF(2); } }
        public string PagoElectronico_LOTE_3 { get { return Pago.PagoElectronico_LOTE(3); } }
        public string PagoElectronico_REF_3 { get { return Pago.PagoElectronico_REF(3); } }
        public string PagoElectronico_LOTE_4 { get { return Pago.PagoElectronico_LOTE(4); } }
        public string PagoElectronico_REF_4 { get { return Pago.PagoElectronico_REF(4); } }


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
            Pago.Limpiar();
            PagoIsOk = false;

            _permisos = permiso;
            Pago.setMontoPagar(monto);
            Pago.setTasaCambio(tasaCambio);

            var frm = new Facturacion.Pago.PagoFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void PagarNotaCredito(OOB.LibVenta.PosOffline.Permiso.Pos.Ficha permiso, decimal monto, decimal tasaCambio, decimal dscto)
        {
            Pago.Limpiar();
            PagoIsOk = false;

            _permisos = permiso;
            Pago.setMontoPagar(monto);
            Pago.setTasaCambio(tasaCambio);
            Pago.setDescuento(dscto);

            var msg = MessageBox.Show("Procesar Pago ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                PagoIsOk = true;
            }
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
            rt=Pago.Procesar(true);
            if (rt) 
            {
                PagoIsOk = true;
            }
            return rt;
        }

        public void ActivarDescuento() 
        {
            var seguir = true;

            if (_permisos.DarDesctoGlobal.RequiereClave == OOB.LibVenta.PosOffline.Permiso.Pos.Permiso.EnumAcceso.SinAcceso)
            {
                seguir = false;
            }
            if (_permisos.DarDesctoGlobal.RequiereClave == OOB.LibVenta.PosOffline.Permiso.Pos.Permiso.EnumAcceso.PedirClave)
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
            var rt = true;

            var seguir = false;
            switch (_permisos.CtaCredito.RequiereClave)
            {
                case OOB.LibVenta.PosOffline.Permiso.Pos.Permiso.EnumAcceso.SinAcceso:
                    seguir = false;
                    break;
                case OOB.LibVenta.PosOffline.Permiso.Pos.Permiso.EnumAcceso.PedirClave:
                    seguir = _seguridad.SolicitarClave();
                    break;
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