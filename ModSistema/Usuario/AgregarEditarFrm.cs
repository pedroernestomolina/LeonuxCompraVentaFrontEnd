using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Usuario
{

    public partial class AgregarEditarFrm : Form
    {

        private GestionAgregarEditar _controlador;
        private bool _modoEditar;


        public AgregarEditarFrm()
        {
            InitializeComponent();
            InicializarControles();
        }

        private void InicializarControles()
        {
            CB_GRUPO.DisplayMember = "nombre";
            CB_GRUPO.ValueMember = "auto";
        }

        public void setTitulo(string p)
        {
            L_TITULO.Text = p;
        }

        private void AgregarEditarFrm_Load(object sender, EventArgs e)
        {
            _modoEditar = false;
            CB_GRUPO.DataSource = _controlador.Source;
            CB_GRUPO.SelectedValue = _controlador.AutoGrupo;
            TB_CODIGO.Text = _controlador.Codigo;
            TB_NOMBRE.Text = _controlador.Nombre;
            TB_APELLIDO.Text = _controlador.Apellido;
            TB_CLAVE .Text = _controlador.Clave;
            TB_CODIGO.Focus();
            _modoEditar = true;
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
            _controlador.Nombre = TB_NOMBRE.Text.Trim().ToUpper();
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_modoEditar)
            {
                if (CB_GRUPO.SelectedValue != null)
                {
                    _controlador.AutoGrupo = CB_GRUPO.SelectedValue.ToString();
                }
            }
        }

        private void TB_CODIGO_TextChanged(object sender, EventArgs e)
        {
            _controlador.Codigo = TB_CODIGO.Text.Trim().ToUpper();
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_APELLIDO_TextChanged(object sender, EventArgs e)
        {
            _controlador.Apellido = TB_APELLIDO.Text.Trim().ToUpper();
        }

        private void TB_CLAVE_TextChanged(object sender, EventArgs e)
        {
            _controlador.Clave = TB_CLAVE.Text;
        }

    }

}