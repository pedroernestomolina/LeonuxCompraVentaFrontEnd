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

    public partial class DescuentoFrm : Form
    {


        private bool _dsctoIsOk;
        private decimal _monto;


        public bool DsctoIsOk 
        {
            get 
            {
                return _dsctoIsOk;
            }
        }
        public decimal DsctoPorcentaje 
        {
            get
            {
                return _monto;
            }
        }


        public DescuentoFrm()
        {
            InitializeComponent();
            _dsctoIsOk = false;
            _monto = 0.0m;
        }

        private void TB_CANTIDAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            _monto = decimal.Parse(TB_CANTIDAD.Text.Trim());
            if (_monto >= 0.0m && _monto<=99.99m) 
            {
                _dsctoIsOk = true;
                Salir();
            }
        }

    }

}