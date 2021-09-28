using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Sucursal
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
            CB_GRUPO.DisplayMember = "nombre";
            CB_GRUPO.ValueMember = "auto";
            CB_GRUPO.DataSource = _controlador.Source;
            CB_GRUPO.SelectedValue = _controlador.AutoGrupo;

            TB_CODIGO.Text = _controlador.Codigo;
            TB_NOMBRE.Text = _controlador.Sucursal;
            CHK_MAYOR.Checked = _controlador.HabilitarFactMayor;
            TB_CODIGO.Focus();
            TB_CODIGO.Enabled = true;
            if (_controlador.Modo == GestionAgregarEditar.enumModo.Editar) 
            {
                TB_CODIGO.Enabled = false;
            }
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
            _controlador.Sucursal = TB_NOMBRE.Text;
        }

        private void CB_GRUPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_GRUPO.SelectedValue != null)
            {
                _controlador.AutoGrupo = CB_GRUPO.SelectedValue.ToString();
            }
        }

        private void TB_CODIGO_TextChanged(object sender, EventArgs e)
        {
            _controlador.Codigo = TB_CODIGO.Text;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    
        private void CHK_MAYOR_Leave(object sender, EventArgs e)
        {
            var estatus=false;
            if (CHK_MAYOR.Checked)
                estatus=true;
            _controlador.setHabilitarFactMayor(estatus);
        }
     
    }

}