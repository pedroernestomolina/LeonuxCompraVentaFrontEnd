using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.ReconversionMonetaria
{

    public partial class ReconversionMonFrm : Form
    {
        
        private Gestion _controlador;


        public ReconversionMonFrm()
        {
            InitializeComponent();
        }


        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_GUARDAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.ActualizacionIsOk)
                Salir();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void ReconversionMonFrm_Load(object sender, EventArgs e)
        {
            TB_FACTOR.Text = _controlador.FactorReconversion.ToString();
            L_ADVERTENCIA.Text = _controlador.Advertencia;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_FACTOR_Leave(object sender, EventArgs e)
        {
            _controlador.setFactorReconversion(decimal.Parse(TB_FACTOR.Text));
        }

        public void ActualizarMensaje()
        {
            L_ADVERTENCIA.Text = _controlador.Advertencia;
        }

    }

}