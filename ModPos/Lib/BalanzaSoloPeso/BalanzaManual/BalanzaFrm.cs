using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Lib.BalanzaSoloPeso.BalanzaManual
{

    public partial class BalanzaFrm : Form
    {


        private decimal _peso;


        public decimal Peso 
        {
            get 
            {
                return _peso;
            }
        }


        public BalanzaFrm()
        {
            InitializeComponent();
        }

        private void BT_SALIDA_Click(object sender, EventArgs e)
        {
            Salida();
        }

        private void Salida()
        {
            this.Close();
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            var tb= TB_PESO.Text.Trim();
            if (tb!= "") 
            {
                _peso = decimal.Parse(tb);
                Salida();
            }
        }

        private void BalanzaFrm_Load(object sender, EventArgs e)
        {
            TB_PESO.Focus();
        }

    }

}