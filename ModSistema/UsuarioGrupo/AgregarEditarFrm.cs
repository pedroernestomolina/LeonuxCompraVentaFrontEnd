using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.UsuarioGrupo
{

    public partial class AgregarEditarFrm : Form
    {

        private GestionAgregarEditar _controlador;


        public AgregarEditarFrm()
        {
            InitializeComponent();
        }

        public void setTitulo(string p)
        {
            L_TITULO.Text = p;
        }

        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            TB_NOMBRE.Text = _controlador.Nombre;
            TB_NOMBRE.Focus();
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
            GuardarData();
        }

        private void GuardarData()
        {
            _controlador.Guardar();
            if (_controlador.IsAgregarEditarOk)
            {
                Salir();
            }
        }

        public void setControlador(GestionAgregarEditar ctr)
        {
            _controlador = ctr;
        }

        private void TB_NOMBRE_TextChanged(object sender, EventArgs e)
        {
            _controlador.Nombre= TB_NOMBRE.Text;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

    }

}