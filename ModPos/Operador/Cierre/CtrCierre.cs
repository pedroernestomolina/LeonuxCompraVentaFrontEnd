using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Operador.Cierre
{
    
    public class CtrCierre
    {


        public bool IsOperadorCerrado { get; set; }
        private cierre _cierre { get; set; }
        private Facturacion.Ticket _ticket;
        private List<string> _lista;


        public cierre MiCierre 
        {
            get 
            {
                return _cierre;
            }
        }

        public  OOB.LibVenta.PosOffline.Operador.Cargar.Ficha Operador
        {
            get
            {
                return Sistema.MyOperador;
            }
        }

        public string Estacion
        {
            get
            {
                return Environment.MachineName;
            }
        }


        public CtrCierre()
        {
            _cierre = new cierre();
            _lista = new List<string>();
            _ticket = new Facturacion.Ticket();
            _ticket.setModo(Facturacion.Ticket.EnumModoTicket.Modo80mm);
            if (Sistema.ImpresoraTicket == Sistema.EnumModoRolloTicket.Pequeno)
            {
                _ticket.setModo(Facturacion.Ticket.EnumModoTicket.Modo58mm);
            }
        }


        public void Cierre() 
        {
            IsOperadorCerrado = false;
            var r00 = Sistema.MyData2.Pendiente_HayCuentasporProcesar();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (r00.Entidad)
            {
                Helpers.Msg.Error("HAY CUENTAS PENDIENTES POR PROCESAR, VERIFIQUE POR FAVOR");
                return;
            }

            var r01 = Sistema.MyData2.Operador_Movimiento(Sistema.MyOperador.Id);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            _cierre.setMovimientos(r01.Entidad);
            var frm = new CierreFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public bool Procesar() 
        {
            var rt = false;
            _lista.Clear();

            var msg = MessageBox.Show("Estas Seguro De Cerrar Este Operador ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.Yes)
            {
                var ficha = new OOB.LibVenta.PosOffline.Operador.Cerrar.Ficha()
                {
                    IdOperador = Sistema.MyOperador.Id,
                    Estatus = "C",
                    Fecha = DateTime.Now,
                    Hora = DateTime.Now.ToShortTimeString(),
                    Movimientos = new OOB.LibVenta.PosOffline.Operador.Cerrar.Movimiento() 
                    {
                        diferencia = _cierre.Diferencia,
                        divisa = _cierre.Movimientos.montoDivisa,
                        efectivo = _cierre.MontoEfectivo ,
                        tarjeta = _cierre.Movimientos.montoElectronico,
                        otros = _cierre.Movimientos.montoOtros ,
                        firma = _cierre.Movimientos.montoDocCredito,
                        devolucion = _cierre.Movimientos.montoNCredito,
                        subTotal = _cierre.SubTotal,
                        total = _cierre.Total ,

                        mEfectivo = _cierre.EntradaPorEfectivo,
                        mDivisa = _cierre.EntradaPorDivisa,
                        mTarjeta = _cierre.EntradaPorTarjeta,
                        mOtro = _cierre.EntradaPorOtro,
                        mFirma = _cierre.EntradaPorCredito,
                        mSubTotal = _cierre.TotalEntrada,
                        mTotal = _cierre.TotalEntrada,
                    },
                };

                _lista.Add("REPORTE CAJA");
                _lista.Add("");
                _lista.Add("EQUIPO: "+Environment.MachineName);
                _lista.Add("OPERAD: "+Sistema.MyOperador.Usuario);
                _lista.Add("FECHA : "+DateTime.Now.ToShortDateString());
                _lista.Add("HORA  : "+DateTime.Now.ToShortTimeString());
                _lista.Add("");
                _lista.Add("");
                _lista.Add("EN FACTURA");
                _lista.Add("Cant     : "+_cierre.Movimientos.cntFactura.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoFactura.ToString("n2"));
                _lista.Add("");
                _lista.Add("EN NT/CREDITO");
                _lista.Add("Cant     : "+_cierre.Movimientos.cntNCredito.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoNCredito.ToString("n2"));
                _lista.Add("");
                _lista.Add("TOTAL VENTA");
                _lista.Add("MONTO    : "+_cierre.MontoVenta.ToString("n0"));
                _lista.Add("");
                _lista.Add("CONTADO  :");
                _lista.Add("Cant     : "+_cierre.Movimientos.cntDocContado.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoDocContado.ToString("n0"));
                _lista.Add("");
                _lista.Add("CREDITO  :");
                _lista.Add("Cant     : "+_cierre.Movimientos.cntDocCredito.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoDocCredito.ToString("n2"));
                _lista.Add("");
                _lista.Add("");
                _lista.Add("DESGLOZE");
                _lista.Add("Efectivo : "+_cierre.Movimientos.cntEfecitvo.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.MontoEfectivo.ToString("n2"));
                _lista.Add("Divisa   : "+_cierre.Movimientos.cntDivisa.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoDivisa.ToString("n2"));
                _lista.Add("Tarjetas : "+_cierre.Movimientos.cntElectronico.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoElectronico.ToString("n2"));
                _lista.Add("Otros    : "+_cierre.Movimientos.cntOtros.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoOtros.ToString("n2"));
                _lista.Add("Devoluc  : "+_cierre.Movimientos.cntNCredito.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoNCredito.ToString("n2"));
                _lista.Add("A Credito: "+_cierre.Movimientos.cntDocCredito.ToString("n0"));
                _lista.Add("Monto    : "+_cierre.Movimientos.montoDocCredito.ToString("n2"));
                _lista.Add("TOTAL    :");
                _lista.Add("Monto    : "+_cierre.Total.ToString("n2"));

                _lista.Add("");
                _lista.Add("");
                _lista.Add("USUARIO");
                _lista.Add("Efectivo : ");
                _lista.Add("Monto    : " + _cierre.EntradaPorEfectivo.ToString("n2"));
                _lista.Add("Divisa   : ");
                _lista.Add("Monto    : " + _cierre.EntradaPorDivisa.ToString("n2"));
                _lista.Add("Tarjetas : ");
                _lista.Add("Monto    : " + _cierre.EntradaPorTarjeta.ToString("n2"));
                _lista.Add("Otros    : ");
                _lista.Add("Monto    : " + _cierre.EntradaPorOtro.ToString("n2"));
                _lista.Add("A Credito: ");
                _lista.Add("Monto    : " + _cierre.Movimientos.montoDocCredito.ToString("n2"));
                _lista.Add("TOTAL    :");
                _lista.Add("Monto    : " + _cierre.TotalEntrada.ToString("n2"));

                var r02 = Sistema.MyData2.Operador_Cerrar(ficha);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                Sistema.MyOperador = null;
                Helpers.Msg.Alerta("OPERADOR CERRRADO EXITOSAMENTE !!!!!");
                IsOperadorCerrado = true;
                rt=true;
            }

            return rt;
        }

        public void setEntradaPorEfectivo(decimal monto)
        {
            _cierre.EntradaPorEfectivo=monto;
        }

        public void setEntradaPorDivisa(decimal monto)
        {
            _cierre.EntradaPorDivisa= monto;
        }

        public void setEntradaPorTarjeta(decimal monto)
        {
            _cierre.EntradaPorTarjeta= monto;
        }

        public void setEntradaPorOtro(decimal monto)
        {
            _cierre.EntradaPorOtro= monto;
        }

        public void Imprimir(System.Drawing.Printing.PrintPageEventArgs e) 
        {
            _ticket.setControlador(e);
            _ticket.Reporte(_lista);
        }

        public void ReporteDetalle()
        {
            var filtro = new OOB.LibVenta.PosOffline.Reporte.Pago.Filtro()
            {
                IdOperador = Sistema.MyOperador.Id,
            };
            var r01 = Sistema.MyData2.Reporte_Pago_Detalle(filtro);
            if (r01.Result== OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var rp1 = new Reportes.Pago.Detalle.Movimiento(r01.Lista);
            rp1.Generar();
        }

        public void NCreditoDetalle()
        {
            var filtro = new OOB.LibVenta.PosOffline.Reporte.NCredito.Filtro()
            {
                IdOperador = Sistema.MyOperador.Id,
            };
            var r01 = Sistema.MyData2.Reporte_NCredito(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var rp1 = new Reportes.NCredito.Movimiento(r01.Lista);
            rp1.Generar();
        }

        public void PagoResumen()
        {
            var filtro = new OOB.LibVenta.PosOffline.Reporte.Pago.Filtro()
            {
                IdOperador = Sistema.MyOperador.Id,
            };
            var r01 = Sistema.MyData2.Reporte_Pago_Resumen(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var rp1 = new Reportes.Pago.Resumen.Movimiento(r01.Lista);
            rp1.Generar();
        }

    }

}