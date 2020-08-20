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

    public partial class LoteReferenciaFrm : Form
    {

        private LoteReferencia _controlador;


        public LoteReferenciaFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            _controlador.Aceptar();
            if (_controlador.IsOk) 
            {
                Salir();
            }
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        public void setControlador(LoteReferencia ctr)
        {
            _controlador = ctr;
        }

        private void TB_LOTE_TextChanged(object sender, EventArgs e)
        {
            _controlador.Lote = TB_LOTE.Text.Trim().ToUpper();
        }

        private void TB_REFERENCIA_TextChanged(object sender, EventArgs e)
        {
            _controlador.Referencia = TB_REFERENCIA.Text.Trim().ToUpper();
        }

        private void LoteReferenciaFrm_Load(object sender, EventArgs e)
        {
            TB_LOTE.Text = _controlador.Lote;
            TB_REFERENCIA.Text = _controlador.Referencia;
            TB_LOTE.Focus();
        }

    }

}