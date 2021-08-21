using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.SerieFiscal
{

    public partial class AgregarEditarFrm : Form
    {

        private AgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
        }


        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            L_TITULO.Text = _controlador.TituloFicha;
            TB_SERIE.Text = _controlador.GetSerie;
            TB_CONTROL.Text = _controlador.GetControl;
            TB_CORRELATIVO.Text = _controlador.GetCorrelativo.ToString();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_SERIE_Leave(object sender, EventArgs e)
        {
            _controlador.setSerie(TB_SERIE.Text.Trim().ToUpper());
        }

        private void TB_CONTROL_Leave(object sender, EventArgs e)
        {
            _controlador.setControl(TB_CONTROL.Text.Trim().ToUpper());
        }

        private void TB_CORRELATIVO_Leave(object sender, EventArgs e)
        {
            _controlador.setCorrelativo(int.Parse(TB_CORRELATIVO.Text));
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
            if (_controlador.SalirIsOk)
                this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
        }

        private void AgregarEditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.SalirIsOk || _controlador.AbandonarIsOk) { }
            else
                e.Cancel = true;
        }

        public void Cerrar()
        {
            this.Close();
        }

        public void setContolador(AgregarEditar ctr)
        {
            _controlador = ctr;
        }

    }

}