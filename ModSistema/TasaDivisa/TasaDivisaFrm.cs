using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.TasaDivisa
{

    public partial class TasaDivisaFrm : Form
    {


        private Gestion _controlador;


        public TasaDivisaFrm()
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

        private void TasaDivisaFrm_Load(object sender, EventArgs e)
        {
            L_TASA.Text = _controlador.TituloFuncion;
            TB_TASA.Text = _controlador.ValorActual.ToString();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_TASA_Leave(object sender, EventArgs e)
        {
            _controlador.ValorNuevo = decimal.Parse(TB_TASA.Text);
        }

    }

}
