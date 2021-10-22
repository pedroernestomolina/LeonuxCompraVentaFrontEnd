using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.DatosNegocio.Editar
{

    public partial class EditarFrm : Form
    {

        Gestion _controlador;


        public EditarFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void EditarFrm_Load(object sender, EventArgs e)
        {
            TB_RIF.Focus();

            TB_RIF.Text = _controlador.Rif;
            TB_NOMBRE.Text = _controlador.Nombre;
            TB_DIRECCION.Text=_controlador.Direccion;
            TB_TELEFONOS.Text = _controlador.Telefonos;

            TB_EMAIL.Text = _controlador.Email;
            TB_WEBSITE.Text = _controlador.WebSite;
            TB_CONTACTO.Text = _controlador.Contacto;
            TB_COD_POSTAL.Text = _controlador.CodPostal;

            TB_PAIS.Text = _controlador.Pais;
            TB_ESTADO.Text = _controlador.Estado;
            TB_CIUDAD.Text = _controlador.Ciudad;

            L_SUCURSAL.Text = _controlador.Sucursal;
            L_CODIGO_SUC.Text = _controlador.CodSucursal;
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
            _controlador.setRif(TB_RIF.Text.Trim().ToUpper());
        }

        private void TB_NOMBRE_Leave(object sender, EventArgs e)
        {
            _controlador.setNombre(TB_NOMBRE.Text.Trim().ToUpper());
        }

        private void TB_DIRECCION_Leave(object sender, EventArgs e)
        {
            _controlador.setDireccion(TB_DIRECCION.Text.Trim());
        }

        private void TB_TELEFONOS_Leave(object sender, EventArgs e)
        {
            _controlador.setTelefonos(TB_TELEFONOS.Text.Trim());
        }

        private void TB_EMAIL_Leave(object sender, EventArgs e)
        {
            _controlador.setEmail(TB_EMAIL.Text.Trim());
        }

        private void TB_WEBSITE_Leave(object sender, EventArgs e)
        {
            _controlador.setWebSite(TB_WEBSITE.Text.Trim());
        }

        private void TB_CONTACTO_Leave(object sender, EventArgs e)
        {
            _controlador.setContacto(TB_CONTACTO.Text.Trim());
        }

        private void TB_COD_POSTAL_Leave(object sender, EventArgs e)
        {
            _controlador.setCodPostal(TB_COD_POSTAL.Text.Trim());
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            TB_RIF.Focus();
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Guardar();
            if (_controlador.IsEditarOk)
            {
                Salir();
            }
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            TB_RIF.Focus();
            Abandonar();
        }

        private void Abandonar()
        {
            _controlador.Abandonar();
        }

        private void EditarFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlador.IsSalirOk || _controlador.IsAbandonaOk)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void TB_PAIS_Leave(object sender, EventArgs e)
        {
            _controlador.setPais(TB_PAIS.Text.Trim().ToUpper());
        }

        private void TB_ESTADO_Leave(object sender, EventArgs e)
        {
            _controlador.setEstado(TB_ESTADO.Text.Trim().ToUpper());
        }

        private void TB_CIUDAD_Leave(object sender, EventArgs e)
        {
            _controlador.setCiudad(TB_CIUDAD.Text.Trim().ToUpper());
        }

    }

}