using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.Maestros.Vendedor
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
            TB_RIF.Text = _controlador.GetRif;
            TB_CODIGO.Text = _controlador.GetCodigo;
            TB_RAZON_SOCIAL.Text = _controlador.GetRazonSocial;
            TB_DIR_FISCAL.Text= _controlador.GetDirFiscal;
            TB_PERSONA.Text = _controlador.GetPersona;
            TB_TELEFONO.Text = _controlador.GetTelefono;
            TB_EMAIL.Text = _controlador.GetEmail;
            TB_WEBSITE.Text = _controlador.GetWebSite;
            TB_ADVERTENCIA.Text = _controlador.GetAdvertencia;
            TB_MEMO.Text = _controlador.GetMemo;
        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void TB_RIF_Leave(object sender, EventArgs e)
        {
            _controlador.setCiRif(TB_RIF.Text.Trim().ToUpper());
        }

        private void TB_CODIGO_Leave(object sender, EventArgs e)
        {
            _controlador.setCodigo(TB_CODIGO.Text.Trim().ToUpper());
        }

        private void TB_RAZON_SOCIAL_Leave(object sender, EventArgs e)
        {
            _controlador.setRazonSocial(TB_RAZON_SOCIAL.Text.Trim().ToUpper());
        }

        private void TB_DIR_FISCAL_Leave(object sender, EventArgs e)
        {
            _controlador.setDirFiscal(TB_DIR_FISCAL.Text);
        }

        private void TB_PERSONA_Leave(object sender, EventArgs e)
        {
            _controlador.setPersona(TB_PERSONA.Text.Trim().ToUpper());
        }

        private void TB_TELEFONO_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefono(TB_TELEFONO.Text.Trim().ToUpper());
        }

        private void TB_EMAIL_Leave(object sender, EventArgs e)
        {
            _controlador.setEmail(TB_EMAIL.Text.Trim());
        }

        private void TB_WEBSITE_Leave(object sender, EventArgs e)
        {
            _controlador.setWebSite(TB_WEBSITE.Text.Trim());
        }

        private void TB_ADVERTENCIA_Leave(object sender, EventArgs e)
        {
            _controlador.setAdvertencia(TB_ADVERTENCIA.Text.Trim().ToUpper());
        }

        private void TB_MEMO_Leave(object sender, EventArgs e)
        {
            _controlador.setMemo(TB_MEMO.Text.Trim().ToUpper());
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