using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Facturacion
{

    public partial class MultiplicarFrm : Form
    {

        private int _cnt;


        public int Cantidad 
        {
            get 
            {
                return _cnt;
            }
        }

        public MultiplicarFrm()
        {
            InitializeComponent();
            Limpiar();
        }

        private void Limpiar()
        {
            _cnt = 0;
            TB_CANTIDAD.Text = "0";
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void MultiplicarFrm_Load(object sender, EventArgs e)
        {
            IrFoco();
        }

        private void IrFoco()
        {
            TB_CANTIDAD.Focus();
        }

        private void TB_OK_Click(object sender, EventArgs e)
        {
            _cnt = int.Parse(TB_CANTIDAD.Text.Trim());
            Salida();
        }

        private void TB_CANTIDAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}