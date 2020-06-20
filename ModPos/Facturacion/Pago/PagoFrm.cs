using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Pago
{

    public partial class PagoFrm : Form
    {

        private CtrPago _controlador;
        private bool _efectivoChanged;
        private bool _divisaChanged;
        private bool _elect_1_Changed;
        private bool _elect_2_Changed;
        private bool _elect_3_Changed;
        private bool _otro_Changed;

             
        public PagoFrm()
        {
            InitializeComponent();
        }

        public void Inicializa(CtrCliente cliente, Venta venta, OOB.LibVenta.PosOffline.Permiso.Pos.Ficha permiso, ClaveSeguridad.Seguridad seguridad) 
        {
            _efectivoChanged = false;
            _divisaChanged = false;
            _elect_1_Changed = false;
            _elect_2_Changed = false;
            _elect_3_Changed = false;
            _otro_Changed = false;
        }
            

        private void PagoFrm_Load(object sender, EventArgs e)
        {
            Limpiar();

            L_CLIENTE.Text = _controlador.FichaCliente;
            L_SUBTOTAL_MONTO_PAGAR.Text = _controlador.Pago.SubTotalMontoPagar.ToString("n2");
            L_VENTA_MONEDA_NACIONAL.Text = _controlador.Pago.MontoPagar.ToString("n2");
            L_VENTA_DIVISA.Text = "$" + _controlador.Pago.MontoPagarDivisa.ToString("n2");
            L_RESTA_MONEDA_NACIONAL.Text = _controlador.Pago.MontoResta_MonedaNacional.ToString("n2");
            L_RESTA_DIVISA.Text = "$" + _controlador.Pago.MontoResta_Divisa.ToString("n2");
            L_TASA_CAMBIO.Text = _controlador.Pago.TasaCambio.ToString("n2");
        }

        private void Limpiar()
        {
            L_MONTO_VENTA.Text = "Monto Venta,  Descuento: " + _controlador.Pago.Descuento.ToString("n2") + "%";
            L_CLIENTE.Text = "";
            L_VENTA_MONEDA_NACIONAL.Text = "0.00";
            L_VENTA_DIVISA.Text = "$0.00";
            LimpiarPago();
        }

        private void LimpiarPago()
        {
            TB_EFECTIVO.Select();
            L_RESTA_MONEDA_NACIONAL.Text = "0.00";
            L_RESTA_DIVISA.Text = "$0.00";
            L_LOTE_1.Text = "";
            L_LOTE_2.Text = "";
            L_LOTE_3.Text = "";
            L_LOTE_4.Text = "";
            L_REF_1.Text = "";
            L_REF_2.Text = "";
            L_REF_3.Text = "";
            L_REF_4.Text = "";
            TB_EFECTIVO.Text = "0";
            TB_DIVISA_CNT.Text = "0";
            TB_DIVISA_MONTO.Text = "0.00";
            TB_MONTO_RECIBIDO.Text = "0.00";
            TB_ELECT_1.Text = "0";
            TB_ELECT_2.Text = "0";
            TB_ELECT_3.Text = "0";
            TB_OTRO.Text = "0";
            _efectivoChanged = false;
            _divisaChanged = false;
            _elect_1_Changed = false;
            _elect_2_Changed = false;
            _elect_3_Changed = false;
            _otro_Changed = false;
        }

        private void Salir()
        {
            this.Close();
        }

        private void TB_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            switch (tb.Name) 
            {
                case "TB_EFECTIVO":
                    _efectivoChanged = true;
                    break;
                case "TB_DIVISA_CNT":
                    _divisaChanged = true;
                    break;
                case "TB_ELECT_1":
                    _elect_1_Changed = true;
                    break;
                case "TB_ELECT_2":
                    _elect_2_Changed = true;
                    break;
                case "TB_ELECT_3":
                    _elect_3_Changed = true;
                    break;
                case "TB_OTRO":
                    _otro_Changed= true;
                    break;
            }
        }

        private void TB_Leave(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var monto = 0.0m;
            switch (tb.Name) 
            {
                case "TB_EFECTIVO":
                    monto = decimal.Parse(TB_EFECTIVO.Text);
                    if (_efectivoChanged)
                    {
                        if (monto >= 0)
                        {
                            _controlador.Pago.AddEfectivo(monto);
                        }
                        _efectivoChanged = false;
                    }
                    break;
                case "TB_DIVISA_CNT":
                    monto = decimal.Parse(TB_DIVISA_CNT.Text);
                    if (_divisaChanged)
                    {
                        if (monto >= 0)
                        {
                            _controlador.Pago.AddDivisa(monto);
                        }
                        _divisaChanged = false;
                    }
                    break;
                case "TB_ELECT_1":
                    monto = decimal.Parse(TB_ELECT_1.Text);
                    if (_elect_1_Changed)
                    {
                        if (monto >= 0)
                        {
                            _controlador.Pago.AddElectronico(monto, 1);
                        }
                        _elect_1_Changed = false;
                    }
                    break;
                case "TB_ELECT_2":
                    monto = decimal.Parse(TB_ELECT_2.Text);
                    if (_elect_2_Changed)
                    {
                        if (monto >= 0)
                        {
                            _controlador.Pago.AddElectronico(monto, 2);
                        }
                        _elect_2_Changed = false;
                    }
                    break;
                case "TB_ELECT_3":
                    monto = decimal.Parse(TB_ELECT_3.Text);
                    if (_elect_3_Changed)
                    {
                        if (monto >= 0)
                        {
                            _controlador.Pago.AddElectronico(monto, 3);
                        }
                        _elect_3_Changed = false;
                    }
                    break;
                case "TB_OTRO":
                    monto = decimal.Parse(TB_OTRO.Text);
                    if (_otro_Changed)
                    {
                        if (monto >= 0)
                        {
                            _controlador.Pago.AddElectronico(monto, 4);
                        }
                        _otro_Changed = false;
                    }
                    break;
            }

            ActualizaMontoResta();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void ActualizaMontoResta()
        {
            if (_controlador.Pago.IsCredito)
            {
                panel12.BackColor = Color.Green;
                L_RESTA_CAMBIO_DAR.Text = "CREDITO HABILITADO";
                L_RESTA_MONEDA_NACIONAL.Text = _controlador.Pago.MontoResta_MonedaNacional.ToString("n2");
                L_RESTA_DIVISA.Text = "$" + _controlador.Pago.MontoResta_Divisa.ToString("n2");
            }
            else
            {
                if (_controlador.Pago.MontoCambioDar_MonedaNacional < 0)
                {
                    panel12.BackColor = Color.Maroon;
                    L_RESTA_CAMBIO_DAR.Text = "Resta/Pendiente";
                    L_RESTA_MONEDA_NACIONAL.Text = _controlador.Pago.MontoResta_MonedaNacional.ToString("n2");
                    L_RESTA_DIVISA.Text = "$" + _controlador.Pago.MontoResta_Divisa.ToString("n2");
                }
                else
                {
                    panel12.BackColor = Color.Navy;
                    L_RESTA_CAMBIO_DAR.Text = "Cambio Dar";
                    L_RESTA_MONEDA_NACIONAL.Text = _controlador.Pago.MontoCambioDar_MonedaNacional.ToString("n2");
                    L_RESTA_DIVISA.Text = "$" + _controlador.Pago.MontoCambioDar_Divisa.ToString("n2");
                }
            }
            TB_DIVISA_MONTO.Text = _controlador.Pago.MontoDivisa.ToString("n2");
            TB_MONTO_RECIBIDO.Text = _controlador.Pago.MontoRecibido.ToString("n2");
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            Limpieza();
        }

        private void Limpieza()
        {
            _controlador.Pago.Limpiar();
            LimpiarPago();
            ActualizarMonto();
            ActualizaMontoResta();
            IrFocoPrincipal();
        }

        private void IrFocoPrincipal()
        {
            TB_EFECTIVO.Focus();
        }

        private void BT_CALCULADORA_Click(object sender, EventArgs e)
        {
            ActivarCalculadora();
        }

        private void ActivarCalculadora()
        {
            _controlador.Calculadora();
            IrFocoPrincipal();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void BT_DESCUENTO_Click(object sender, EventArgs e)
        {
            DarDescuento();
        }

        private void DarDescuento()
        {
            _controlador.ActivarDescuento();
            ActualizarMonto();
            ActualizaMontoResta();
            IrFocoPrincipal();
        }

        private void ActualizarMonto()
        {
            L_MONTO_VENTA.Text = "Monto Venta,  Descuento: " + _controlador.Pago.DescuentoPorct.ToString("n2") + "%";
            L_VENTA_MONEDA_NACIONAL.Text = _controlador.Pago.MontoPagar.ToString("n2");
            L_VENTA_DIVISA.Text = "$" + _controlador.Pago.MontoPagarDivisa.ToString("n2");
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void BT_CREDITO_Click(object sender, EventArgs e)
        {
            DarCredito();
        }

        private void DarCredito()
        {
            if (_controlador.ActivarCredito()) 
            {
                LimpiarPago();
                ActualizaMontoResta();
                this.Close();
            }
            IrFocoPrincipal();
        }

        private void Procesar()
        {
            if (_controlador.Procesar())
            {
                this.Close();
            }
            else 
            {
                IrFocoPrincipal();
            }
        }

        private void TB_MONTO_RECIBIDO_Leave(object sender, EventArgs e)
        {
            if (_controlador.Pago.MontoResta_MonedaNacional > 0)
            {
                IrFocoPrincipal();
            }
            else
            {
                BT_PROCESAR.Select();
            }
        }

        public void setControlador(CtrPago ctr) 
        {
            _controlador = ctr;
        }

        private void PagoFrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                DarDescuento();
            }
            if (e.KeyCode == Keys.F3)
            {
                DarCredito();
            }
        }

    }

}