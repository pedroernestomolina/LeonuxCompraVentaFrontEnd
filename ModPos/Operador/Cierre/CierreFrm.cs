using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Operador.Cierre
{

    public partial class CierreFrm : Form
    {


        private CtrCierre _controlador;


        public CierreFrm()
        {
            InitializeComponent();
        }

        private void CierreFrm_Load(object sender, EventArgs e)
        {
            Limpiar();
            ActualizarData();
        }

        private void ActualizarData()
        {
            L_ESTACION.Text = _controlador.Estacion;
            L_USUARIO.Text = _controlador.Operador.Usuario;
            L_FECHA_HORA.Text = _controlador.Operador.FechaApertura.ToShortDateString() + ", " + _controlador.Operador.HoraApertura;

            L_CNT_DOC_FACTURA.Text = _controlador.MiCierre.Movimientos.cntFactura.ToString("n0");
            L_CNT_DOC_NCREDITO.Text = _controlador.MiCierre.Movimientos.cntNCredito.ToString("n0");

            L_MONTO_VENTA.Text = _controlador.MiCierre.MontoVenta.ToString("n2");

            L_MONTO_DOC_FACTURA.Text = _controlador.MiCierre.Movimientos.montoFactura.ToString("n2");
            L_MONTO_DOC_NCREDITO.Text = _controlador.MiCierre.Movimientos.montoNCredito.ToString("n2");

            L_CNT_DOC_CONTADO.Text = _controlador.MiCierre.CntDocContado.ToString("n0");
            L_CNT_DOC_CREDITO.Text = _controlador.MiCierre.Movimientos.cntDocCredito.ToString("n0");
            L_MONTO_DOC_CONTADO.Text = _controlador.MiCierre.MontoDocContado.ToString("n2");
            L_MONTO_DOC_CREDITO.Text = _controlador.MiCierre.Movimientos.montoDocCredito.ToString("n2");

            L_CNT_EFECTIVO.Text = _controlador.MiCierre.Movimientos.cntEfecitvo.ToString("n0"); ;
            L_CNT_DIVISA.Text = _controlador.MiCierre.Movimientos.cntDivisa.ToString("n0");
            L_CNT_TARJETAS.Text = _controlador.MiCierre.Movimientos.cntElectronico.ToString("n0");
            L_CNT_OTROS.Text = _controlador.MiCierre.Movimientos.cntOtros.ToString("n0");
            L_CNT_DEVOLUCION.Text = _controlador.MiCierre.Movimientos.cntNCredito.ToString("n0");
            L_CNT_CREDITO.Text = _controlador.MiCierre.Movimientos.cntDocCredito.ToString("n0");

            L_MONTO_EFECTIVO.Text = _controlador.MiCierre.MontoEfectivo.ToString("n2");
            L_MONTO_DIVISA.Text = _controlador.MiCierre.Movimientos.montoDivisa.ToString("n2");
            L_MONTO_TARJETAS.Text = _controlador.MiCierre.Movimientos.montoElectronico.ToString("n2");
            L_MONTO_OTROS.Text = _controlador.MiCierre.Movimientos.montoOtros.ToString("n2");
            L_MONTO_DEVOLUCION.Text = _controlador.MiCierre.Movimientos.montoNCredito.ToString("n2");
            L_MONTO_CREDITO.Text = _controlador.MiCierre.Movimientos.montoDocCredito.ToString("n2");

            L_MONTO_DESGLOZE.Text = _controlador.MiCierre.MontoDesgloze.ToString("n2");
            L_TOTAL_ENTRADA.Text = "0.00";

            TB_CREDITO.Text = _controlador.MiCierre.Movimientos.montoDocCredito.ToString("n2");
            ActualizaDiferencia();
        }

        private void ActualizaDiferencia()
        {
            L_DIFERENCIA.ForeColor = Color.Green;
            if (_controlador.MiCierre.Diferencia > 0)
            {
                L_DIFERENCIA.ForeColor = Color.Blue;
            }
            else if (_controlador.MiCierre.Diferencia < 0)
            {
                L_DIFERENCIA.ForeColor = Color.Red;
            }
            L_DIFERENCIA.Text = _controlador.MiCierre.Diferencia.ToString("n2");
        }

        private void Limpiar()
        {
            L_FECHA_HORA.Text = "";
            L_USUARIO.Text = "";
        }

        public void setControlador(CtrCierre ctr)
        {
            _controlador=ctr;
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            if (_controlador.Procesar()) 
            {
                printDocument1.Print();
                Salir();
            }
        }

        private void TB_TextChanged(object sender, EventArgs e)
        {
            var mEfectivo = decimal.Parse(TB_EFECTIVO.Text);
            var mDivisa = decimal.Parse(TB_DIVISA.Text);
            var mTarjeta = decimal.Parse(TB_TARJETA.Text);
            var mOtro = decimal.Parse(TB_OTRO.Text);
            _controlador.setEntradaPorEfectivo(mEfectivo);
            _controlador.setEntradaPorDivisa(mDivisa);
            _controlador.setEntradaPorTarjeta(mTarjeta);
            _controlador.setEntradaPorOtro(mOtro);
            //L_TOTAL_ENTRADA.Text = (mEfectivo + mDivisa + mTarjeta + mOtro).ToString("n2");
            L_TOTAL_ENTRADA.Text = _controlador.MiCierre.TotalEntrada.ToString("n2");
            ActualizaDiferencia();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            _controlador.Imprimir(e);
        }

        private void BT_DETALLE_Click(object sender, EventArgs e)
        {
            ReporteDetalle();
        }

        private void ReporteDetalle()
        {
            _controlador.ReporteDetalle();
        }

        private void BT_NC_DETALLE_Click(object sender, EventArgs e)
        {
            NCreditoDetalle();
        }

        private void NCreditoDetalle()
        {
            _controlador.NCreditoDetalle();
        }

        private void BT_PAGO_RESUMEN_Click(object sender, EventArgs e)
        {
            PagoResumen();
        }

        private void PagoResumen()
        {
            _controlador.PagoResumen();
        }
    
    }

}