using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Precio
{

    public partial class ActualizarFrm : Form
    {

        private Gestion _controlador;


        public ActualizarFrm()
        {
            InitializeComponent();
        }

        private void ActualizarFrm_Load(object sender, EventArgs e)
        {
            TB_ET1.Text = _controlador.Etiqueta_1;
            TB_ET2.Text = _controlador.Etiqueta_2;
            TB_ET3.Text = _controlador.Etiqueta_3;
            TB_ET4.Text = _controlador.Etiqueta_4;
            TB_ET5.Text = _controlador.Etiqueta_5;
            TB_ET1.Focus();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TB_ET1_TextChanged(object sender, EventArgs e)
        {
            _controlador.Etiqueta_1 = TB_ET1.Text;
        }

        private void TB_ET2_TextChanged(object sender, EventArgs e)
        {
            _controlador.Etiqueta_2 = TB_ET2.Text;
        }

        private void TB_ET3_TextChanged(object sender, EventArgs e)
        {
            _controlador.Etiqueta_3 = TB_ET3.Text;
        }

        private void TB_ET4_TextChanged(object sender, EventArgs e)
        {
            _controlador.Etiqueta_4 = TB_ET4.Text;
        }

        private void TB_ET5_TextChanged(object sender, EventArgs e)
        {
            _controlador.Etiqueta_5 = TB_ET5.Text;
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
            Guardar();
        }

        private void Guardar()
        {
            _controlador.Procesar();
            if (_controlador.IsActualizarOk) 
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

        private void ActualizarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _controlador.CancelarCierreVentana;
            _controlador.InicializarIsCerrarHabilitado();
        }

    }

}