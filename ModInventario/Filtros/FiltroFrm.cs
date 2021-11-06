using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Filtros
{

    public partial class FiltroFrm : Form
    {


        private Gestion _controlador;


        public FiltroFrm()
        {
            InitializeComponent();
            InicializaControles();
        }

        private void InicializaControles()
        {
            CB_DEP_ORIGEN.DisplayMember = "Nombre";
            CB_DEP_ORIGEN.ValueMember = "Auto";
            CB_DEP_DESTINO.DisplayMember = "Nombre";
            CB_DEP_DESTINO.ValueMember = "Auto";
            CB_ESTATUS.DisplayMember = "Descripcion";
            CB_ESTATUS.ValueMember = "Id";
            CB_CONCEPTO.DisplayMember = "Nombre";
            CB_CONCEPTO.ValueMember = "Auto";
        }

        private void FiltroFrm_Load(object sender, EventArgs e)
        {
            CB_DEP_ORIGEN.DataSource=_controlador.SourceDepOrigen;
            CB_DEP_DESTINO.DataSource = _controlador.SourceDepDestino;
            CB_ESTATUS.DataSource = _controlador.SourceEstatus;
            CB_CONCEPTO.DataSource = _controlador.SourceConcepto;

            CB_DEP_ORIGEN.Enabled = _controlador.ActivarDepOrigen;
            CB_DEP_DESTINO.Enabled = _controlador.ActivarDepDestino;
            CB_ESTATUS.Enabled = _controlador.ActivarEstatus;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void L_PRODUCTO_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }

        private void L_DEP_ORIGEN_Click(object sender, EventArgs e)
        {
            LimpiarDepOrigen();
        }

        private void L_DEP_DESTINO_Click(object sender, EventArgs e)
        {
            LimpiarDepDestino();
        }

        private void L_ESTATUS_Click(object sender, EventArgs e)
        {
            LimpiarEstatus();
        }

        private void LimpiarProducto()
        {
            _controlador.setProducto("");
            TB_PRODUCTO.Text = "";
        }

        private void LimpiarEstatus()
        {
            CB_ESTATUS.SelectedIndex = -1;
        }

        private void LimpiarDepDestino()
        {
            CB_DEP_DESTINO.SelectedIndex = -1;
        }

        private void LimpiarDepOrigen()
        {
            CB_DEP_ORIGEN.SelectedIndex = -1;
        }

        private void CB_DEP_ORIGEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setDepOrigen("");
            if (CB_DEP_ORIGEN.SelectedIndex != -1)
            {
                _controlador.setDepOrigen(CB_DEP_ORIGEN.SelectedValue.ToString());
            }
        }

        private void CB_DEP_DESTINO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setDepDestino("");
            if (CB_DEP_DESTINO.SelectedIndex != -1)
            {
                _controlador.setDepDestino(CB_DEP_DESTINO.SelectedValue.ToString());
            }
        }

        private void CB_ESTATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setEstatus("");
            if (CB_ESTATUS.SelectedIndex != -1)
            {
                _controlador.setEstatus(CB_ESTATUS.SelectedValue.ToString());
            }
        }

        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void LimpiarFiltros()
        {
            LimpiarProducto();
            LimpiarDepOrigen();
            LimpiarDepDestino();
            LimpiarEstatus();
            LimpiarConcepto();
        }

        private void LimpiarConcepto()
        {
            CB_CONCEPTO.SelectedIndex = -1;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_FILTRAR_Click(object sender, EventArgs e)
        {
            _controlador.Filtrar();
            Salir();
        }

        private void L_CONCEPTO_Click(object sender, EventArgs e)
        {
            CB_CONCEPTO.SelectedIndex = -1;
        }

        private void CB_CONCEPTO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.setConcepto("");
            if (CB_CONCEPTO.SelectedIndex != -1)
            {
                _controlador.setConcepto(CB_CONCEPTO.SelectedValue.ToString());
            }
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_PRODUCTO_BUSCAR_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        private void BuscarProducto()
        {
            _controlador.BuscarProducto();
            if (_controlador.ProductoSeleccioandoIsOk)
            {
                TB_PRODUCTO.Text = _controlador.ProductoAFiltrar;
            }
            else
            {
                TB_PRODUCTO.Text = "";
            }
        }

        private void TB_PRODUCTO_Leave(object sender, EventArgs e)
        {
            _controlador.setProducto(TB_PRODUCTO.Text.Trim().ToUpper());
        }

    }

}