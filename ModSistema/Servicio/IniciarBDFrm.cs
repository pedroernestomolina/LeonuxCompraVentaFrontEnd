using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Servicio
{

    public partial class IniciarBDFrm : Form
    {

        private Gestion _controlador;


        public IniciarBDFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        private void IniciarBDFrm_Load(object sender, EventArgs e)
        {
            TB_SUCURSAL.Text = _controlador.Sucursal;
            TB_EQUIPO.Text = _controlador.Equipo;
            P_DATA.Enabled = _controlador.HabilitarEntrada;
        }

        private void TB_SUCURSAL_Leave(object sender, EventArgs e)
        {
            TB_SUCURSAL.Text=TB_SUCURSAL.Text.Trim().ToUpper();
            _controlador.Sucursal = TB_SUCURSAL.Text;
        }

        private void TB_EQUIPO_Leave(object sender, EventArgs e)
        {
            TB_EQUIPO.Text = TB_EQUIPO.Text.Trim().ToUpper();
            _controlador.Equipo = TB_EQUIPO.Text;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_SUCURSAL_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = TB_SUCURSAL.Text.Trim() == "";
        }

        private void TB_EQUIPO_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = TB_EQUIPO.Text.Trim() == "";
        }

    }

}
