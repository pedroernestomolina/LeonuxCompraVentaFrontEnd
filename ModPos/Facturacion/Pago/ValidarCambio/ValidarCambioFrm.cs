using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion.Pago.ValidarCambio
{
    
    public partial class ValidarCambioFrm : Form
    {


        private Gestion _controlador;

        
        public ValidarCambioFrm()
        {
            InitializeComponent();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ValidarCambioFrm_Load(object sender, EventArgs e)
        {
            TB_MONTO.Text = "0";
            IrFoco();
        }

        private void TB_MONTO_Leave(object sender, EventArgs e)
        {
            var monto= decimal.Parse(TB_MONTO.Text);
            _controlador.setMontoCapturado(monto);
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            IrFoco();
            this.Close();
        }

        private void IrFoco()
        {
            TB_MONTO.Focus();
        }

        private void CTRL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            Close();
        }

    }

}